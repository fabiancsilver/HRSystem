import { Employee } from "./employee.model";
import { Permission } from "./permission.model";

export interface PermissionEmployee {  
  PermissionID: number;
  EmployeeID: number;
  
  Permission: Permission;
  Employee: Employee;
}
