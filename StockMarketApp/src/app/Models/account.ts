export class Account {
    public id:string;
  public userName:string;
  public password:string;
  public email:string;
  public mobile:bigint;
  public userType:UserType
  public token: string;
}

export enum UserType {
    Admin = 1,
    User
}