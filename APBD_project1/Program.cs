using APBD_project1.Models;
using APBD_project1.Services;

var service = new BusinessLogic();

// Device
var laptop1 = new Laptop("Dell XPS", "RTX4070", "i7");
var laptop2 = new Laptop("HP Solid", "RTX5090", "i5");
var camera1 = new Camera("Canon", 24, true);
var camera2 = new Camera("Kodak", 16, false);
var projector1 = new Projector("Epson EB-FH08", 48, false);
var projector2 = new Projector("Samsung Whale Pro", 64, true);

