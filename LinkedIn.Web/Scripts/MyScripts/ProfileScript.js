function HideResetModel(){
    //console.log("Hide Clear");

    $("#FullModal").modal('hide');
    document.getElementById("ModelForm").reset();
}
function ResetModel() {
    document.getElementById("ModelForm").reset();
}

function EditExp(expId){
    console.log("EDIT BUTTON => " + expId);
    $.ajax({
        method: "GET",
        data: { id: expId},
        url: 'Profile/GetWorkExp',
        contentType: "application/json",
        dataType: "json",
        success: function (response) {
            console.log("success");
            console.log(response.Title);
            console.log(response.EmploymentType);
            console.log(response.Location);
            console.log(response.Description);
            console.log(response.StartMonth);
            console.log(response.StartYear);
        },
        error: function (response) {
            console.log('error = ' + response.responseText);
        }
    })
}
function DeleteExp(expId) {
  
    $.ajax({
        method: "GET",
        data: { expId: expId },
        url: '/Profile/DeleteExperience',
        contentType: "application/json",
        dataType: "json",
       

    });

    $("#" + expId).remove();
     
    
}


$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip({
        title: `<div class="list-group">

        <a href="#" class="list-group-item list-group-item-action">Publication</a>
        <a href="#" class="list-group-item list-group-item-action">Course</a>
        <a href="#" class="list-group-item list-group-item-action">Project</a>
        <a href="#" class="list-group-item list-group-item-action">Language</a>
        <a href="#" class="list-group-item list-group-item-action">Organisation</a>
        </div>`,

        html: true,
        trigger: "click"
    });
    $(".tooltip.bottom .tooltip-arrow").css("border-bottom-color", "red");
});

var arr = document.querySelectorAll(".btn--show");
for (var i = 0; i < arr.length; i++) {
    document.querySelector(".btn--show").addEventListener("click", function (e) {
        if (e.target.matches(".btn")) {
            var id = e.target.id;
            id = id.substr(4, 1);
            console.log(id);
            if (id == 1) {
                document.querySelector("#btn-2").classList.add("btn--active");
                document.querySelector("#btn-1").classList.remove("btn--active");
            } else {
                document.querySelector("#btn-2").classList.remove("btn--active");
                document.querySelector("#btn-1").classList.add("btn--active");
            }
            document.querySelector(".tools").classList.toggle("tools--active");
        }
    });
}

$("#PresentWorkDate").css({ display: "none" });
$("#CurrentlyWorking").change(function () {
    if ($(this).is(":checked")) {
        $("#PresentWorkDate").css({ display: "block" });
        $("#EndWorkDate").css({ display: "none" });
    } else {
        $("#PresentWorkDate").css({ display: "none" });
        $("#EndWorkDate").css({ display: "flex" });
    }
});
