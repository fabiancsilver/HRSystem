import { AddressType } from "./address-type.model";

export interface Address {  
  AddressID: number;  
  EmployeeID: number;  
  AddressTypeID: number;
  Line1: string;
  City: string;
  State: string;
  Country: string;  
  ZipCode: string;
  AddressType: AddressType;
}
