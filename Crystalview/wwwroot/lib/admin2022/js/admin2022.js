window.onload = function () {
  if (window.location.hash === "#ar") {
    document.body.classList.remove("english");
    document.body.classList.add("arabic");
    button.textContent = "English";
  } else if (window.location.hash === "#eng") {
    document.body.classList.remove("arabic");
    document.body.classList.add("english");
    button.textContent = "Arabic";
  }
  if (window.location.hash) {
    let lang;
    if (window.location.hash === "#ar") {
      lang = "ar";
    } else {
      lang = "eng";
    }
      document.getElementById("ProfessionalMeeting").textContent = data[lang].ProfessionalMeeting;
    document.getElementById("information").textContent = data[lang].information;
    document.getElementById("login-title").textContent = data[lang].loginTitle;
    document.querySelector(`label[for="exampleInputEmail1"]`).textContent =
      data[lang].email;
    document.querySelector(`label[for="exampleInputPassword1"]`).textContent =
      data[lang].password;
    //document.querySelector(`label[for="exampleCheck1"]`).textContent =
    //  data[lang].remember;
  //  document.querySelector(`#login`).textContent = data[lang].submit;
  }
};
let data = {
  eng: {
    ProfessionalMeeting: "Gym Management",
    information: "Attribution is appreciated and allows contributors to gain exposure",
    loginTitle: "LOGIN",
    email: "Email address",
    emailHint: "We'll never share your email with anyone else.",
    password: "Password",
    remember: "Remember Me",
    submit: "Login",
  },
  ar: {
    ProfessionalMeeting: "الاجتماع المهني",
    information: "يُقدَّر الإسناد ويسمح للمساهمين باكتساب التعرض",
    loginTitle: "التسجيل",
    email: "الحساب الإلكترونى",
    emailHint: "لن نشارك بريدك الإلكتروني مع أي شخص آخر.",
    password: "كلمة المرور",
    remember: "تذكرنى",
    submit: "دخول",
  },
};

let button = document.querySelector(".lang");
button.addEventListener("click", () => {
  if (button.textContent === "Arabic") {
    button.textContent = "English";
    document.body.classList.remove("english");
    document.body.classList.add("arabic");
    button.setAttribute("href", "#ar");
    setTimeout(function () {
      location.reload(true);
    }, 10);
  } else if (button.textContent === "English") {
    button.textContent = "Arabic";
    button.setAttribute("href", "#eng");
    document.body.classList.remove("arabic");
    document.body.classList.add("english");
    setTimeout(function () {
      location.reload(true);
    }, 100);
  }
});


