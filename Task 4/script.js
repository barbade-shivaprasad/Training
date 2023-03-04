const requiredFields = ['name','email','organization'];
const validationFields = ['email','telephone','website']

let userInputs = document.getElementsByTagName('input');

for(let i=0;i<userInputs.length;i++){
    
    userInputs[i].addEventListener('input',(event)=>{

        document.getElementById('error-msg').textContent = "";

        let element = document.getElementById(`${event.target.id}-error-msg`)
        let capitalized;
        if(element != null){

            if(event.target.value.trim() != ""){
                element.textContent = ""
                element.previousElementSibling.style.display = 'block'
            }
            else{

                capitalized = event.target.id.charAt(0).toUpperCase()+event.target.id.slice(1);
                element.previousElementSibling.style.display = 'none'
                element.textContent = `${capitalized} is required`;
            }
        }

        let elementId = event.target.id;
        
        if(validationFields.includes(elementId))
            if(isValid(elementId))
                removeErrorMsg(elementId)
            else
                addErrorMsg(elementId)
    
    })
}

const removeErrorMsg=(elementId)=>{
    document.getElementById(`${elementId}-error-msg`).textContent = ""
    document.getElementById(`${elementId}-error-msg`).previousElementSibling.style.display = 'block'
}
const addErrorMsg=(elementId)=>{
    document.getElementById(`${elementId}-error-msg`).textContent = `Invalid ${elementId}`
    document.getElementById(`${elementId}-error-msg`).previousElementSibling.style.display = 'none'    
}

const submitForm=()=>{
    

    let errorFlag = false;

    requiredFields.forEach((element)=>{

        let capitalized = element.charAt(0).toUpperCase()+element.slice(1);

        if(document.getElementById(element)!=null)
            if(isEmpty(element))
            {   
                document.getElementById(`${element}-error-msg`).textContent = `${capitalized} is required`;
                document.getElementById(`${element}-error-msg`).previousElementSibling.style.display = 'none'
                errorFlag = true;
                document.body.scrollTop = 0;
            } 
    });
    
    validationFields.forEach((element)=>{

        if(!requiredFields.includes(element))
            if(isValid(element))
            removeErrorMsg(element)
            else{
                addErrorMsg(element)
                errorFlag = true;
            }
    })
    
    
    if(errorFlag){
        document.getElementById('error-msg').textContent = 'Please fill all the required fields below.';
    }
    else{
        alert('Success')
        clearForm('career-form');
        clearForm('contact-form');
    }

}

const isEmpty=(id)=>{
    if(document.getElementById(id).value.trim() =='')
        return true;

    return false;
}


const isValid=(elementType)=>{

    let element = document.getElementById(elementType);
    if(element == null || element.value=="")
    return true;

    let pattern;
    switch(elementType){

        case 'email':
            pattern = /^[a-zA-Z][a-zA-Z0-9\._\-]*@[a-zA-Z\-]+((\.[a-z]+$)|(\.[a-z]{2}\.[a-z]+$))$/
            break;
        
        case 'telephone':
            pattern = /^[6-9][0-9]{9}$/
            break;

        case 'website':
            pattern = /^[a-zA-Z0-9][a-zA-Z0-9\.]*\.[a-zA-Z]+$/
            break;
        
    }

    return pattern.test(element.value);
}

const setPromo=()=>{

    let state = document.getElementById('state').value

    if(state != 'none')
    document.getElementById('promotion-code').value = `${state}-PROMO`
}

const greet=()=>{

    let gender = document.getElementsByName('gender');

    for(let i=0;i<gender.length;i++){
        if(gender[i].checked){

            if(gender[i].value=='Male')
            window.alert("Hello Sir!")
            else
            window.alert("Hello Lady!")
        }
    }
}

const clearForm=(formName)=>{
    document.getElementById(formName).reset();
    let errorList = document.getElementsByClassName('error');

    for(let i=0;i<errorList.length;i++){
        errorList[i].textContent = ""
    }
}

document.querySelector('.btn-clear').addEventListener("click", clearForm('contact-form'))

function getFileName(){
    let filePath = document.getElementById('file-upload').value;
    let fileName = filePath.split('\\');
    fileName = fileName[fileName.length - 1]
    document.getElementById('file-name').value = fileName;
}