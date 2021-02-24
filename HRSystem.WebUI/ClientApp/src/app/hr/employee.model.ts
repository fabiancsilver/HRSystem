import { Color } from "./color.model";
import { Department } from "./department.model";
import { Phone } from "./phone.model";
import { Position } from "./position.model";
import { Shift } from "./shift.model";
import { Status } from "./status.model";

export interface Employee {
  EmployeeID: number;
  Name: string;
  StartDate: Date;
  EndDate: Date;
  PositionID: number;
  DepartmentID: number;
  StatusID: number;
  ShiftID: number;
  ManagerID?: number;
  //TeamMemberPhoto: string;
  PreferredPhoneID?: number;

  FavoriteColor: Color;
  Position: Position;
  Department: Department;
  Status: Status;
  Shift: Shift;
  Manager: Employee;
  PreferredPhone: Phone;
}
