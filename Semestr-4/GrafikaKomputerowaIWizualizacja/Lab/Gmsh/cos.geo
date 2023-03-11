// Gmsh project created on Tue Apr 26 11:28:27 2022
SetFactory("OpenCASCADE");
//+
x=0.1;
Point(1) = {-0.5, 0.5, 0, x};
//+
Point(2) = {0.5, 0.5, 0, x};
//+
Point(3) = {0, 0, 0, x};
//+
Point(4) = {-0.5, -1, 0, x};
//+
Point(5) = {0.5, -1, 0, x};
//+
Point(6) = {-0.25, -0.8, 0, x};
//+
Point(7) = {0.25, -0.8, 0, x};
//+
Point(8) = {0.25, -1, 0, x};
//+
Point(9) = {-0.25, -1, 0, x};
//+
Line(1) = {1, 3};
//+
Line(2) = {3, 2};
//+
Line(3) = {2, 5};
//+
Line(4) = {5, 8};
//+
Line(5) = {8, 7};
//+
Line(6) = {7, 6};
//+
Line(7) = {6, 9};
//+
Line(8) = {9, 4};
//+
Line(9) = {4, 1};
//+
Curve Loop(1) = {1, 2, 3, 4, 5, 6, 7, 8, 9};
//+
Plane Surface(1) = {1};
//+
Extrude {0, 0, 2} {
  Surface{1}; 
}
