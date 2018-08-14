import { PhoneNumber } from "./phone-number";

export interface Contact {
  name: string;
  email: string;
  organization: string;
  phoneNumbers: Array<PhoneNumber>;
}
