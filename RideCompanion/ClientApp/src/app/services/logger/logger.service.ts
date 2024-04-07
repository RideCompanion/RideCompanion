import {Injectable} from "@angular/core";

@Injectable()
export class ConsoleLogger {
  log(message: string): void {
    console.log(message);
  }
}
