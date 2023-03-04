export class Address{
    street:string;
    city : string;
    state : string;
    postalCode : number;

    constructor(street:string,city:string,state:string,postalCode:number){
        this.street = street;
        this.city = city;
        this.state = state;
        this.postalCode = postalCode;
    }

}