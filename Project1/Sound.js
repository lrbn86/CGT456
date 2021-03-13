const BGMSource = document.getElementById("BackgroundMusic");
const buttonSource = document.getElementById("ButtonSound");
const buttons = document.getElementsByClassName("NumberButton");

BGMSource.volume = 0.10;
BGMSource.loop = true;

buttonSource.volume = 0.30;

document.getElementById('form1').addEventListener('submit', function (evt) {
    buttonSource.play();
})