"use strict";

var todaysDate = new Date();
var today = todaysDate.getDay();

// fetch handlebars template and .compile it
// fetch API data and .json it
fetch(`https://localhost:5001/api/messages/${today}`).then(function (jsonData) {
  return jsonData.json();
}).then(function (motivationApiData) {
  fetch('template.hbs').then(function (handlebarsTemplateData) {
    return handlebarsTemplateData.text();
  }).then(function (messageTemplate) {
    var htmlTemplate = Handlebars.compile(messageTemplate);
    var todaysMessage = {};

    //todaysMessage.items = githubApiData.items.slice(0,6);
    var todaysMessageInHtml = htmlTemplate(todaysMessage);
    document.querySelector('.message').innerHTML = todaysMessageInHtml;
  });
});