import { Address } from "./models/addressModel.js";
import { Contact } from "./models/contactModel.js";
import { DataProviderService } from "./services/DataProviderService.js";

let contactList: Contact[] = [];
let selectedId: string = "";
let requiredFields = ["name","email","mobile"];
let validationFields = ["website","landline"];
let isAddButton = true;

async function initialize() {

    let data = await DataProviderService.getContacts();
    data.forEach((ele:Contact)=>{
        contactList.push(new Contact(ele.name,ele.email,ele.mobile,ele.landline,ele.website,ele.address,ele.id));
    })
    
    contactList.forEach((ele) => {
        renderContact(ele);
    })
    setEventListeners();

    let id = contactList[0].id;
    selectContact(String(id));
}
function renderContact(contactObj:Contact){
    
    let contactsContainer = document.querySelector('.contacts-container');

    let contactWrapper = document.createElement('div');
    contactWrapper.classList.add('contact-item');
    contactWrapper.id = String(contactObj.id);

    let nameEle = document.createElement('p');
    nameEle.textContent = contactObj.name;
    nameEle.classList.add('name');

    let emailEle = document.createElement('p');
    emailEle.textContent = contactObj.email;
    emailEle.classList.add('email')

    let mobileEle = document.createElement('p');
    mobileEle.textContent = contactObj.mobile;
    mobileEle.classList.add('mobile')

    contactWrapper.appendChild(nameEle);
    contactWrapper.appendChild(emailEle);
    contactWrapper.appendChild(mobileEle);

    contactWrapper.addEventListener('click', e=>{selectContact(String(contactObj.id))});
    contactsContainer?.appendChild(contactWrapper);
}


function setEventListeners() {

    document.getElementById('btn-add')?.addEventListener('click',(e)=>{
        if(isAddButton)
        addContact();
        else
        editContact();
    });

    document.getElementById('edit')?.addEventListener('click',setFormData);
    document.getElementById('delete')?.addEventListener('click',deleteContact);
    document.getElementById('add-item')?.addEventListener('click',e=>displayForm('add'));
    document.getElementById('close-icon')?.addEventListener('click',closeForm);

    let inputFields = document.querySelectorAll('input');
    for(let inputField of inputFields){
        inputField.addEventListener('input',()=>validate(inputField.id));
    }
};

function selectContact(id: string){
    let previousElement;
    if(selectedId != ""){
        previousElement = document.getElementById(selectedId) as HTMLElement;
        previousElement.style.backgroundColor = '#ffffff';
    }

    let selectedElement = document.getElementById(id) as HTMLElement;
    selectedElement.style.backgroundColor = '#cee7f2';
    selectedId = id as string;
    setContactDetails();

};

async function setContactDetails() {
    let contact:Contact = await DataProviderService.getContact(Number.parseInt(selectedId));
    document.getElementById('contact-name')!.textContent = contact.name;
    document.getElementById('contact-email')!.textContent = `Email: ${contact.email}`;
    document.getElementById('contact-mobile')!.textContent = `Mobile: ${contact.mobile}`;

    if(contact.landline != null)
    document.getElementById('contact-landline')!.textContent = `Landline: ${contact.landline}`;
    else
    document.getElementById('contact-landline')!.textContent = '';


    if(contact.website != null)
    document.getElementById('contact-website')!.textContent = `Website: ${contact.website}`;
    else
    document.getElementById('contact-website')!.textContent = "";



    let addressEle = document.getElementById('contact-address');
    let addressLabel = document.getElementById('address-label');

    addressEle!.innerHTML = "";
    addressLabel!.textContent = "";

    if(contact.address != null){

        addressLabel!.textContent = "Address :";
        let address = `<p>${contact.address.street}</p> 
                        <p>${contact.address.city}</p>
                        <p>${contact.address.state}</p>
                        <p>${contact.address.postalCode}</p>`

        addressEle!.innerHTML = address;
        
    }
    

    document.getElementById('contact-card')?.classList.remove('d-none');
    document.getElementById('form-container')?.classList.add('d-none');
}

function getFormData(){
    let name = (<HTMLInputElement>document.getElementById('name')).value;
    let email = (<HTMLInputElement>document.getElementById('email')).value;
    let mobile = (<HTMLInputElement>document.getElementById('mobile')).value;
    let landline = (<HTMLInputElement>document.getElementById('landline')).value;
    let website:string|null = (<HTMLInputElement>document.getElementById('website')).value;
    let address = (<HTMLInputElement>document.getElementById('address')).value;
    let InputAddress = address.split('\n');
    let fullAddress:Address = new Address(InputAddress[0],InputAddress[1],InputAddress[2],Number(InputAddress[3]));
     
    if(website == "")
    website = null;

    return (new Contact(name,email,mobile,landline,website,fullAddress,0));
}


async function addContact(){

    let arr = [...requiredFields,...validationFields];
    let flag = true;
    arr.forEach((ele)=>{
        if(!validate(ele))
            flag = false
    })
    if(!flag)
    return;

    let formData = getFormData();
    let id = await DataProviderService.addContact(formData);

    console.log("Add",id);
    formData.id = Number(id);
    
    contactList.push(await DataProviderService.getContact(Number(id)));
    renderContact(formData);

    selectContact(id);
    
    document.getElementById('overlay')?.classList.remove('t-10');

}

async function editContact(){

    let arr = [...requiredFields,...validationFields];
    let flag = true;
    arr.forEach((ele)=>{
        if(!validate(ele))
            flag = false
    })
    if(!flag)
    return;

    let id = Number(selectedId);
    let formData = getFormData();
    formData.id = id;

    let currentElement = <HTMLElement>document.getElementById(selectedId);
    currentElement.querySelector('.name')!.textContent = formData.name;
    currentElement.querySelector('.email')!.textContent = formData.email;
    currentElement.querySelector('.mobile')!.textContent = formData.mobile;

    for(let i=0;i<contactList.length; i++){
        if(contactList[i].id == id){
            contactList[i] = formData;
        }
    }

    console.log(formData);
    await DataProviderService.updateContact(formData);
    selectContact(selectedId)

    document.getElementById('overlay')?.classList.remove('t-10');
}

async function setFormData(){

    displayForm('edit');
    let ele:Contact = await DataProviderService.getContact(Number.parseInt(selectedId));
    let address = `${ele.address.street}\n${ele.address.city}\n${ele.address.state}\n${ele.address.postalCode}`;


    (<HTMLInputElement>document.getElementById('name')).value = ele.name;
    (<HTMLInputElement>document.getElementById('email')).value  = ele.email;
    (<HTMLInputElement>document.getElementById('mobile')).value = ele.mobile;
    (<HTMLInputElement>document.getElementById('landline')).value = ele.landline as string;
    (<HTMLInputElement>document.getElementById('website')).value = ele.website as string;
    (<HTMLInputElement>document.getElementById('address')).value = address;
}

async function deleteContact(){
    document.getElementById(selectedId)?.remove();
    
    let tempId = Number.parseInt(selectedId);
    let id = await DataProviderService.getPreviousId(tempId) + "";

    console.log("Id",id)

    contactList = contactList.filter((ele)=>{
        if(ele.id != tempId)
        return ele
    })

    await DataProviderService.deleteContact(tempId);
    selectedId = "";
    if(id != ""){
        selectContact(id);
    }
    else
    document.getElementById('contact-card')?.classList.add('d-none');
    
}

function displayForm(formType:string){

    (<HTMLFormElement>document.getElementById('contact-form'))?.reset()
    removeErrorMsg("name");
    removeErrorMsg("email");
    removeErrorMsg("mobile");
    let addBtn = document.getElementById('btn-add');

    if(formType=="edit"){
        isAddButton = false;
        addBtn!.textContent = 'Edit';
    }
    else if(formType=="add"){
        isAddButton = true;
        addBtn!.textContent = 'Add';
    }

    document.getElementById('form-container')?.classList.remove('d-none');
    document.getElementById('contact-card')?.classList.add('d-none');
    document.getElementById('overlay')?.classList.add('t-10');                       //to add overlay

}

function closeForm(){
    document.getElementById('form-container')?.classList.add('d-none');
    document.getElementById('overlay')?.classList.remove('t-10');
    selectContact(selectedId);
}

function validate(inputField:string):boolean{

    let element = <HTMLInputElement>document.getElementById(inputField);
    if(requiredFields.includes(inputField)){
        if(element.value.trim()==""){
            displayErrorMsg(inputField,"required");
            return false;
        }
        else
        {
            if(!isValid(inputField)){
                displayErrorMsg(inputField,"validation");
                return false;
            }
        }
        removeErrorMsg(inputField);
    }
    else if(validationFields.includes(inputField)){
        if(!isValid(inputField)){
            displayErrorMsg(inputField,"validation");
            return false;
        }
        removeErrorMsg(inputField);
    }
    return true;
}

function isValid(inputField:string){
    let element = <HTMLInputElement>document.getElementById(inputField);
    if(element == null || element.value=="")
    return true;

    let pattern:RegExp;
    switch(inputField){

        case 'email':
            pattern = /^[a-zA-Z][a-zA-Z0-9\._\-]*@[a-zA-Z\-]+((\.[a-z]+$)|(\.[a-z]{2}\.[a-z]+$))$/
            break;
        
        case 'mobile':
            pattern = /(^((\+91)|(\+91 ))[6-9][0-9]{9}$)|(^[6-9][0-9]{9}$)/
            break;

        case 'website':
            pattern = /^http:\/\/[a-zA-Z0-9_\-]+\.[a-zA-Z0-9_\-.]*\.[a-zA-Z0-9_\-]+$/
            break;
        case 'landline':
            pattern = /^[0-9]\d{2,4}\d{6,8}$/
            break;
        default:
            pattern = /.*/
    }

    return pattern.test(element.value);
}

function displayErrorMsg(id:string,errorType:string){

    let element = document.getElementById(`${id}-error-msg`);
    if(errorType == "required")
    element!.textContent = id.charAt(0).toUpperCase()+id.slice(1)+ ' is required';
    else if(errorType == "validation")
    element!.textContent = id.charAt(0).toUpperCase()+id.slice(1)+' is invalid';
}
function removeErrorMsg(id:string){

    let element = document.getElementById(`${id}-error-msg`);
    element!.textContent = "";
}

initialize();


