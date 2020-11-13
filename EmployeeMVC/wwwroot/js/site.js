// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function AddEpyValid() {
    var fName = $("#FirstName").val()
    var lName = $("#LastName").val()
    if (fName == "" || lName == "") {
        alert("请填写姓与名！")
        return false;
    }
    return true;
}