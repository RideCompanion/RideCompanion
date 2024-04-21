import { IAddress } from "../IAddress";
import { IRide } from "../ride/IRide";

export interface ICompanion {
  id: string;
  name: string;
  username: string;
  email: string;
  birthDate: Date;
  phone: string;
  website: string;
  address: IAddress;
  rides?: IRide[]
}
