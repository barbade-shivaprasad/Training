import { Address } from "./addressModel";
export class Contact{
    id:number;
    name: string;
    email: string;
    mobile: string;
    landline: string | null;
    website: string | null;
    address: Address;

    constructor(name: string, email: string, mobile: string, landline: string|null, website: string|null, address: Address,id:number) {

        this.id = id;
        this.name = name;
        this.email = email;
        this.mobile = mobile;
        this.landline = landline;
        this.website = website;
        this.address = address;
    }
}