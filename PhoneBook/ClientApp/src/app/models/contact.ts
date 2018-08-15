import { PhoneNumber } from "./phone-number";

export class Contact {
  name: string;
  email: string;
  organization: string;
  phoneNumbers: Array<PhoneNumber>;
}
