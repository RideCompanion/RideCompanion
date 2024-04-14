import { IAddress } from "../IAddress";
import { IRide } from "../ride/IRide";

export interface IDriver {
  id: string;
  firstname: string;
  lastname: string;
  birthdate: Date;
  address: IAddress;

  rides?: IRide[]
}
