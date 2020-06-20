'use strict';


var todaysDate = new Date();
var today = todaysDate.getDay();

var headers = new Headers();
headers.append('Origin','http://localhost:5500');

var motivationUrl = `https://localhost:5001/api/messages/${today}`;

fetch(`${motivationUrl}`, { headers: headers }).then(function (jsonData) {
  return jsonData.json();

}).then(function (todaysMessage) {
  fetch('template.hbs').then(function (handlebarsTemplateData) {
    return handlebarsTemplateData.text();

  }).then(function (messageTemplate) {
    var htmlTemplate = Handlebars.compile(messageTemplate);
    var todaysMessageInHtml = htmlTemplate(todaysMessage);
    document.querySelector('.todaysMessage').innerHTML = todaysMessageInHtml;
  });
});