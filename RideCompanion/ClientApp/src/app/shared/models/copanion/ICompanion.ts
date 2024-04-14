import { IAddress } from "../IAddress";
import { IRide } from "../ride/IRide";

export interface ICompanion {
  id: string,
  firstName: string;
  lastName: string;
  birthDate: Date;
  address: IAddress;

  rides?: IRide[]
}
