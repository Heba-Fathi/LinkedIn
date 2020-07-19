function Respond(id) {
    var acc = document.getElementById(id + "+acc")
    var req = document.getElementById(id + "+req")
    console.log(acc);
    console.log(req);
    acc.style.display="none"
    req.style.display = "none"

}
function Pending(id) {
    var acc = document.getElementById(id + "+con")
    acc.textContent = "Pending"
    acc.disabled="true"

}