import {user} from '../models/userModel.js';


let usersList:user[] = [];
let selectedRowIds:string[] = [];
let checkBoxArr:NodeListOf<Element>;

async function initialize(){
    
    let data = await getData();
    data.forEach((ele:user)=>{
        usersList.push(new user(ele.id,ele.name,ele.score,ele.email));
    });
    
    let tableContainer = document.getElementById('content-table');
    usersList.forEach((ele)=>{
        
        let row = document.createElement('tr');
        let checkBoxColumn = document.createElement('td');
        checkBoxColumn.classList.add('check-box')
        
        let divEle = document.createElement('div');
        divEle.classList.add("checkbox-wrapper");
        let checkBox = document.createElement('input');
        checkBox.type = "checkbox";
        checkBox.id = ele.id;
        checkBox.classList.add("input-checkbox");
        divEle.appendChild(checkBox);
        checkBoxColumn.appendChild(divEle);
        row.appendChild(checkBoxColumn);
        
        let nameColumn = document.createElement('td');
        nameColumn.classList.add('name');
        nameColumn.textContent = ele.name;
        row.appendChild(nameColumn);
        
        let scoreColumn = document.createElement('td');
        scoreColumn.classList.add('score');
        scoreColumn.textContent = String(ele.score);
        row.appendChild(scoreColumn);
        
        let emailColumn = document.createElement('td');
        emailColumn.classList.add('email');
        emailColumn.textContent = ele.email;
        row.appendChild(emailColumn);
        
        let emptyColumn = document.createElement('td');
        emailColumn.classList.add('empty');
        row.appendChild(emptyColumn)
        
        tableContainer?.appendChild(row)
        
    });
    
    setEventListeners();
};

const getData = async()=>{
    let res = await fetch("./users.json");
    let data = await res.json();
    return data;    
}

function setEventListeners(){
    (<HTMLInputElement>document.getElementById("search"))?.addEventListener('input',event=>search(event));
    document.getElementById('select-all')?.addEventListener('change',event=>selectAll(event));
    document.querySelector('.btn-calculate')?.addEventListener('click',calculate);
    
    
    checkBoxArr = document.querySelectorAll(".input-checkbox");
    for (let i of checkBoxArr){
        i.addEventListener("change",selectRow);
        i.addEventListener('change',toggleCheckbox);
    }; 
}

function search(event:Event){

    let searchKey = (<HTMLInputElement>event.target)?.value
    let pattern = searchKey.replace(/[.*+?^${}()|[\]\\]/g,"\\$&");
    let regex = new RegExp(pattern,'gi');
    let nameList = document.getElementsByClassName('name');
    let scoreList = document.getElementsByClassName('score');
    let emailList = document.getElementsByClassName('email');
    
    let elementsArr = [...nameList,...scoreList,...emailList];
    
    for(let i of elementsArr){
        let content = i.textContent;
        i.innerHTML = content!.replaceAll(regex,`<mark>${searchKey}</mark>`)
    }
    
}

function selectAll(event:Event){
    
    selectedRowIds = [];
    if((<HTMLInputElement>event.target)?.checked){
        for(let i of checkBoxArr){
            (<HTMLInputElement>i).checked = true;
            selectedRowIds.push(i.id);
        }
    }
    else{
        for(let i of checkBoxArr){
            (<HTMLInputElement>i).checked = false;
        }
    }
}

function calculate(){

    let scores = [];
    for(let i of usersList){
        if(selectedRowIds.includes(i.id))
            scores.push(i.score);
    }

    (<HTMLElement>document.querySelector('.avg')).textContent = "Average : "+getAvg(scores);
    (<HTMLElement>document.querySelector('.max')).textContent = "Max : "+getMax(scores);
    
}

function getAvg(Arr:number[]):number{

    if(Arr.length == 0)
    return 0;

    let sum = Arr.reduce((total,ele)=>total+=ele);
    let avg = Math.round((sum/Arr.length)*100)/100;
    return avg;
}

function getMax(Arr:number[]):number{

    if(Arr.length==0)
    return 0;

    return Math.max(...Arr);
}

function selectRow(event:Event){
    let element = <HTMLInputElement>event.target;

    if(element.checked)
    selectedRowIds.push(element.id);
    else
    {
        let index = selectedRowIds.indexOf(element.id);
        selectedRowIds.splice(index,1);
    }
}

function toggleCheckbox(){

    let arr = Array.from(checkBoxArr);

    (<HTMLInputElement>document.getElementById('select-all')).checked = arr.every((ele:Element)=>{
        return (<HTMLInputElement>ele).checked});
}

initialize();



