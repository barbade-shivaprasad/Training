$(document).ready(function () {
  $(":input").on("input", function () {
    if($(this).next().next().text() == ""){
        $(this).next().show();
    }
    else{
      $(this).next().hide();
    }
  });

  $("input[name=gender]").on("click", function(){
        greet(this)
  });

  $('.btn-clear').on('click',clearForm);

  setPromo()
});


function greet(element) {
    if ($(element).val() == "Male") 
        alert("Hello Sir!");

    if ($(element).val() == "Female") 
        alert("Hello Lady!");
}

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

$(document).ready(function(){
  $.validator.addMethod(
    "regex",
    function(value, element,pattern) {

      pattern = new RegExp(pattern)
      return this.optional(element) || pattern.test(value);
    },
    "Please check your input."
  );

  $("form").validate({
    rules:{
      name:{
        required:true
      },
      email:{
        required:true,
        email:true
      },
      telephone:{
        regex:"^[6-9][0-9]{9}$"
      },
      website:{
        regex:"^[a-zA-Z0-9][a-zA-Z0-9\\.]*\\.[a-zA-Z]+$"
      },
      organization:{
        required:true
      }
    },
    messages:{
      name:{
        required:"Name is required"
      },
      email:{
        required:"Email is required",
        email:"Invalid email"
      },
      telephone:{
        regex:"Invalid Telephone"
      },
      website:{
        regex:"Invalid website url"
      },
      organization:{
        required:"Organization is required"
      }
    },

    errorPlacement :function(error,element){
        let errContainer = element.next().next()
        error.appendTo(errContainer)
        element.next().hide();
        $('#err-msg').text("Please fill required Details")
    }
  });
})

