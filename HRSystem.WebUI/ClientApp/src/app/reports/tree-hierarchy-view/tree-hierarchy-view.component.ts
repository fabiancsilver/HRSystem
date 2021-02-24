import { ArrayDataSource } from '@angular/cdk/collections';
import { NestedTreeControl } from '@angular/cdk/tree';
import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';

import { EmployeeService } from '../../hr/employee.service';

interface NestedNode {
  Name: string;
  children?: NestedNode[];
}

@Component({
  selector: 'app-tree-hierarchy-view',
  templateUrl: './tree-hierarchy-view.component.html',
  styleUrls: ['./tree-hierarchy-view.component.css']
})
export class TreeHierarchyViewComponent implements OnInit {

  treeControl = new NestedTreeControl<NestedNode>(node => node.children);
  dataSource: ArrayDataSource<NestedNode>;

  hasChild = (_: number, node: NestedNode) => !!node.children && node.children.length > 0;

  constructor(private employeeService: EmployeeService) {

  }

  ngOnInit(): void {
    this.employeeService.getAll('Name', 'asc', null)
      .pipe(
        map(employees => {
          return employees.map(element => {
            return { EmployeeID: element.EmployeeID, Name: `${element.Name} (${element.Position.Name})` , ManagerID: element.ManagerID };
          });
        })
      )
      .subscribe((employees) => {
        employees = this.unflatten(employees); 

        this.dataSource = new ArrayDataSource(employees);
      });
  }
  

  unflatten(items) {
    var tree = [],
      mappedArr = {}

    // Build a hash table and map items to objects
    items.forEach(function (item) {
      var id = item.EmployeeID;
      if (!mappedArr.hasOwnProperty(id)) { // in case of duplicates
        mappedArr[id] = item; // the extracted id as key, and the item as value
        mappedArr[id].children = [];  // under each item, add a key "children" with an empty array as value
      }
    })

    // Loop over hash table
    for (var id in mappedArr) {
      if (mappedArr.hasOwnProperty(id)) {
        let mappedElem = mappedArr[id];

        // If the element is not at the root level, add it to its parent array of children. Note this will continue till we have only root level elements left
        if (mappedElem.ManagerID) {
          var parentId = mappedElem.ManagerID;
          mappedArr[parentId].children.push(mappedElem);
        }

        // If the element is at the root level, directly push to the tree
        else {
          tree.push(mappedElem);
        }
      }
    }
    return tree;
  }
}
