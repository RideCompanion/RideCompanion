import { RideStatusEnum } from "../../enums/ride-status-enum";
import { ICompanion } from "../copanion/ICompanion";
import { IDriver } from "../driver/IDriver";

export interface IRide {
  id: string;
  from: string;
  to: string;
  date: Date;
  price: number;
  status: RideStatusEnum;

  companionId?: string;
  companion?: ICompanion;

  driverId?: string;
  driver?: IDriver;
}
