import { PhoneNumber } from "./phone-number";

export class Contact {
  id: string;
  name: string;
  email: string;
  organization: string;
  phoneNumbers: Array<PhoneNumber>;
}
