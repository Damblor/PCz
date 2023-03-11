// Gmsh project created on Tue Apr 26 10:33:24 2022
SetFactory("OpenCASCADE");
//+
x=0.1;
Point(1) = {0, 0, 0, x};
//+
Point(2) = {0.06, 0, 0, x};
//+
Point(3) = {0, 0.06, 0, x};
//+
Point(4) = {-0.06, 0, 0, x};
//+
Point(5) = {0, -0.06, 0, x};
//+
Circle(1) = {4, 1, 3};
//+
Circle(2) = {3, 1, 2};
//+
Circle(3) = {2, 1, 5};
//+
Circle(4) = {5, 1, 4};
//+
Curve Loop(5) = {1, 2, 3, 4};
//+
Plane Surface(1) = {5};
//+
Extrude {0, 0, 1} {
  Surface{1}; 
}
