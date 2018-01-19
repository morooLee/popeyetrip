var navToggleValue = false;
function navClick() {
    if (!navToggleValue) {
        document.body.style.overflow = 'hidden';
        navToggleValue = true;
    } else {
        document.body.style.overflow = 'auto';
        navToggleValue = false;
    }
};

function NavbarToggle() {
    var btn_NavbarToggle = document.getElementById("navbartoggle");
    btn_NavbarToggle.click();
};

function BlockInput(action) {
    var blockInput = document.getElementById("closesquare");
    var openLogin = document.getElementById("loginsquare");
    var openJoin = document.getElementById("joinsquare");
    var boolToggle = document.getElementById("booltoggle");
    var blockArea = document.getElementById("blockarea");
    var activeLogin = document.getElementById("activelogin");

    if (boolToggle.className === "visible-xs navbar-collapse in") {
        blockArea.style.display = "none";
        NavbarToggle();
    }

    blockInput.className = "closesqaure";

    if (action === "loginsquare") {
        openLogin.style.display = "block";
        openLogin.className = "loginsquare";
        openJoin.style.display = "none";
        document.body.style.overflow = 'hidden';
    }
    else {
        openJoin.style.display = "block";
        openJoin.className = "joinsquare";
        openLogin.style.display = "none";
        document.body.style.overflow = 'hidden';
    }

    activeLogin.className = "activelogin";
};

function UnBlockInput() {
    var blockInput = document.getElementById("closesquare");
    var openLogin = document.getElementById("loginsquare");
    var openJoin = document.getElementById("joinsquare");
    var blockArea = document.getElementById("blockarea");
    var activeLogin = document.getElementById("activelogin");

    blockInput.className = "";
    openLogin.className = "";
    openJoin.className = "";
    blockArea.style.display = "block";
    activeLogin.className = "unactivelogin";
    document.body.style.overflow = 'auto';
};