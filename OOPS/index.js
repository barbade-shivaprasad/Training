class student{
    firstName;
    lastName;
    getName=()=>{
        return this.firstName+" "+this.lastName
    }
    getDetailsNoAccess=()=>{
        return firstName+" "+lastName
    }
    setName=(fname,lname)=>{
        this.firstName = fname;
        this.lastName = lname
    }
    setName=(fname)=>{
        this.firstName = fname;
    }
    constructor(fname,lname){
        this.firstName = fname;
        this.lastName = lname;
    }
}
class ClassMonitor extends student{
    constructor(fname,lname){
        super(fname,lname)
    }
}
let s1 = new student("shiva","prasad")
let c1 = new ClassMonitor("Kiran","kumar");
console.log(c1.getName())
s1.setName("BSP")
console.log(s1.getName())
// console.log(s1.getDetailsNoAccess())