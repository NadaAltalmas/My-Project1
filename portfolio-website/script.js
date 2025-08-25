document.getElementById("contactBtn").addEventListener("click", function() {
    const email = document.getElementById("email");
    if (email.style.display ==="none") {
        email.style.display ="block";
    }
    else{
        email.style.display ="none";
    }
});