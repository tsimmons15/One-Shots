// Written using p5js
// Can demonstrate the irrationality of phi

function setup() {
  createCanvas(800, 800);
  colorMode(RGB, 100);
  noLoop();
}

function draw() {
  originx = 250;
  originy = 250;
  background(255);
  layers = 5;
  seeds = layers * 360;
  phi = (1 + Math.sqrt(5))/2;
  x = 1;
  h = 1;
  translate(originx, originy)
  for (i = 0; i < seeds; i++) {
    r = random(255);
    g = random(255);
    b = random(255);
    
    fill(r, g, b);
    circle(0, 0, 15);
    translate(1+i*x, 0);
    //rotate(phi);
    rotate(phi);
  }
}
