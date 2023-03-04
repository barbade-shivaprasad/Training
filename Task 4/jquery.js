const requiredFields = ["name", "email", "organization"];
const validationFields = ["email", "telephone", "website"];

let errorFlag = false;

$(document).ready(function () {

  $(":input").on("input", function () {
    $("#error-msg").text("");
    checkIfEmpty($(this));
    checkIfValid($(this));
  });

  $("input[name=gender]").on("click", function(){
        greet(this)
  });

  $('.btn-clear').on('click',clearForm);

  $('form').on('submit',function(event){
        event.preventDefault()
        submitForm();        
  });

  setPromo()


});


function greet(element) {

    if ($(element).val() == "Male") 
        alert("Hello Sir!");

    if ($(element).val() == "Female") 
        alert("Hello Lady!");
}

function submitForm(){
    errorFlag = false;

    requiredFields.forEach((elementId)=>{
        checkIfEmpty($(`#${elementId}`));
    })

    validationFields.forEach((elementId)=>{
        checkIfValid($(`#${elementId}`));
    })

    
    if(!errorFlag){
        alert("success!")
        clearForm()
    }
    else{
        $("#error-msg").text("Please Fill all Required fields.")
        document.body.scrollTop = 0;
    }
}


function checkIfEmpty(element) {

  
  let requiredSymbol = element.next();
  let errorMsg = element.next().next();
  
  if (requiredFields.includes(element.attr("id"))) {
    if (element.val().trim() == "") {

      requiredSymbol.hide();
      errorMsg.text(element.attr("id") + " is required");

      errorFlag = true;
    } else {
      requiredSymbol.show();
      errorMsg.text("");
    }
  }
}

function checkIfValid(element) {
  let elementId = element.attr("id");

  let requiredSymbol = element.next();
  let errorMsg = element.next().next();

  if (validationFields.includes(elementId)) {

    if(requiredFields.includes(elementId) && errorMsg.text() !="")
    return;

    if (isValid(elementId)) {
        
      requiredSymbol.show();
      errorMsg.text("");

    } 
    else{
      requiredSymbol.hide();
      errorMsg.text(elementId + " is invalid");
      errorFlag = true;
    }
  }
}

const isValid = (elementType) => {
  let element = $(`#${elementType}`);

  if (element == null || element.val().trim() == "") return true;

  let pattern;
  switch (elementType) {
    case "email":
      pattern =
        /^[a-zA-Z][a-zA-Z0-9\._\-]*@[a-zA-Z\-]+((\.[a-z]+$)|(\.[a-z]{2}\.[a-z]{2,3}$))$/;
      break;

    case "telephone":
      pattern = /^[6-9][0-9]{9}$/;
      break;

    case "website":
      pattern = /^[a-zA-Z0-9][a-zA-Z0-9\.]*\.[a-zA-Z]+$/;
      break;
  }

  return pattern.test(element.val());
};

function clearForm() {

    $("#contact-form")[0].reset();
    $('.error').text("")
    $('.required-symbol').show();
}


function setPromo(){
    $('#state').on('change',function(){
        $("#promotion-code").val($(this).val()+"-PROMO")
    })
}

function getFileName(){
    let filePath = $('#file-upload').val();
    let fileName = filePath.split('\\');
    fileName = fileName[fileName.length - 1]
    $('#file-name').val(fileName);

}
