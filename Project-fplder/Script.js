document.addEventListener("DOMContentLoaded", function() {
    console.log("Welcome to my portfolio!");
});

document.querySelector("form").addEventListener("submit", function(event) {
    event.preventDefault();
    alert("Thenk you for your message!");
});

const scrollBtn = document.createElement("button");
scrollBtn.innerText = "Top";
scrollBtn.id = "scrollToTop";
document.body.appendChild(scrollBtn);

scrollBtn.style.position ="fixed";
scrollBtn.style.bottom = "20px";
scrollBtn.style.right = "20px";
scrollBtn.style.display = "none";

window.addEventListener("scroll", () => {
    if(window.scrolly > 300) {
        scrollBtn.style.display ="block";
    }
    else {
        scrollBtn.style.display ="none";
    }
});

scrollBtn.addEventListener("click", () => {
    window.scrollTo ({ top: 0, behavior: "smooth"})
});