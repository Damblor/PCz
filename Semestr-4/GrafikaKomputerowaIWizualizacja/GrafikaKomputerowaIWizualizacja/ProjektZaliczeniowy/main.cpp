/*
 * GLUT Shapes Demo
 *
 * Written by Nigel Stewart November 2003
 *
 * This program is test harness for the sphere, cone
 * and torus shapes in GLUT.
 *
 * Spinning wireframe and smooth shaded shapes are
 * displayed until the ESC or q key is pressed.  The
 * number of geometry stacks and slices can be adjusted
 * using the + and - keys.
 */

#ifdef __APPLE__
#include <GLUT/glut.h>
#else
#include <GL/glut.h>
#endif

#include <stdlib.h>
#include <cmath>

#include "biblioteka.h"

using namespace std;

struct Position
{
	double X, Y, Z;
	Position(double x, double y, double z) : X(x), Y(y), Z(z) {}
};

struct Dimensions
{
	double A, B, C;
	Dimensions(double a, double b, double c) : A(a), B(b), C(c) {}
};

struct Rotation
{
	double X, Y, Z;
	Rotation(double x, double y, double z) : X(x), Y(y), Z(z) {}
};

struct Texture
{
	GLuint TextureTable[6];
	Texture(GLuint texture) : TextureTable{ texture, texture, texture, texture, texture, texture } {}
	Texture(GLuint texture1, GLuint texture2, GLuint texture3, GLuint texture4, GLuint texture5, GLuint texture6) : TextureTable{ texture1, texture2, texture3, texture4, texture5, texture6 } {}
};

struct CameraPosition
{
	double horizontalAngle;
	double verticalAngle;
	double distance;
	CameraPosition(double horizontal, double vertical, double ldistance) : horizontalAngle(horizontal), verticalAngle(vertical), distance(ldistance) {}
};

enum class CameraType
{
	PERSP,
	ORTO
};

const char* plikiTextur[] = {
  ".\\assets\\wood1.tga",
  ".\\assets\\wood2.tga",
  ".\\assets\\azalea_top.tga",
  ".\\assets\\acacia_log.tga",
};

const int liczbaTekstur = 4;
GLuint obiektyTextur[liczbaTekstur];

Position globalPosition(3, 5.4, 0);
Rotation globalRotation(0, 0, 0);

CameraPosition cameraPostiton(1, 0.5, 10);
CameraType currentCamera = CameraType::PERSP;

int mouseX = 0, mouseY = 0;
bool rotateCamera = false;

Texture* woodTexture1;
Texture* woodTexture2;
Texture* woodTexture3;
Texture* logTexture;
Texture* leafTexture;

GLfloat light0Ambient[] = { 0.0f, 0.0f, 0.0f, 1.0f };
GLfloat light0Diffuse[] = { 1.0f, 1.0f, 0.3f, 1.0f };
GLfloat light0DiffuseR[] = { 1.0f, 1.0f, 1.0f, 1.0f };
GLfloat light0Specular[] = { 0.4f, 0.4f, 0.4f, 1.0f };
GLfloat light0Position[] = { 10.0f, 1.0f, 0.0f, 0.0f };

GLfloat light1Ambient[] = { 0.0f, 0.0f, 0.0f, 1.0f };
GLfloat light1Diffuse[] = { 0.0f, 0.0f, 1.0f, 1.0f };
GLfloat light1DiffuseR[] = { 0.0f, 0.0f, 1.0f, 1.0f };
GLfloat light1Specular[] = { 1.0f, 1.0f, 1.0f, 1.0f };
GLfloat light1Position[] = { -10.0f, 1.0f, 0.0f, 0.0f };

bool light = true, light0 = true, light1 = true;
double lightIntensity = 1, lightsRotation = 20;

static void resize(int width, int height)
{
	glViewport(0, 0, width, height);
}

void RenderLight()
{
	//Change intensivity
	for (int i = 0; i < 4; i++)
	{
		light0DiffuseR[i] = light0Diffuse[i] * lightIntensity;
		light1DiffuseR[i] = light1Diffuse[i] * lightIntensity;
	}

	//Rotale light (day/night)
	light0Position[0] = (float)sin(glpDegToRad(lightsRotation)) * 30.0f;
	light0Position[1] = (float)cos(glpDegToRad(lightsRotation)) * 30.0f;
	light1Position[0] = (float)sin(glpDegToRad(lightsRotation)) * -30.0f;
	light1Position[1] = (float)cos(glpDegToRad(lightsRotation)) * -30.0f;

	glLightfv(GL_LIGHT0, GL_AMBIENT, light0Ambient);
	glLightfv(GL_LIGHT0, GL_DIFFUSE, light0DiffuseR);
	glLightfv(GL_LIGHT0, GL_SPECULAR, light0Specular);
	glLightfv(GL_LIGHT0, GL_POSITION, light0Position);

	glLightfv(GL_LIGHT1, GL_AMBIENT, light1Ambient);
	glLightfv(GL_LIGHT1, GL_DIFFUSE, light1DiffuseR);
	glLightfv(GL_LIGHT1, GL_SPECULAR, light1Specular);
	glLightfv(GL_LIGHT1, GL_POSITION, light1Position);
}

void RenderCamera()
{
	const float ar = (float)glutGet(GLUT_WINDOW_WIDTH) / (float)glutGet(GLUT_WINDOW_HEIGHT);

	double maxAngle = 1.5, maxDistance = 30, minDistance = 1;

	//Check camera position
	if (cameraPostiton.distance > maxDistance)
		cameraPostiton.distance = maxDistance;
	else if (cameraPostiton.distance < minDistance)
		cameraPostiton.distance = minDistance;

	if (cameraPostiton.verticalAngle > maxAngle)
		cameraPostiton.verticalAngle = maxAngle;
	else if (cameraPostiton.verticalAngle < -maxAngle)
		cameraPostiton.verticalAngle = -maxAngle;

	//Update camera position
	double distance = currentCamera == CameraType::PERSP ? cameraPostiton.distance : 30.0;
	double x = distance * cos(cameraPostiton.verticalAngle) * cos(cameraPostiton.horizontalAngle);
	double z = distance * cos(cameraPostiton.verticalAngle) * sin(cameraPostiton.horizontalAngle);
	double y = distance * sin(cameraPostiton.verticalAngle);

	//Render camera
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	if (currentCamera == CameraType::PERSP)
		gluPerspective(90.0, ar, 0.1, 100.0);
	else if (currentCamera == CameraType::ORTO)
		glOrtho(-ar * cameraPostiton.distance, ar * cameraPostiton.distance, -cameraPostiton.distance, cameraPostiton.distance, 0.1, 100.0);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	gluLookAt(x, y, z, 0, 0, 0, 0, 1, 0);
}

//Render cuboid
void RenderCuboid(Position position, Dimensions dimension, Rotation rotation, Texture texture)
{
	double x = 0, y = 0, z = 0;

	glPushMatrix();

	glTranslated(position.X, position.Y, position.Z);
	glRotated(rotation.X, 1, 0, 0);
	glRotated(rotation.Y, 0, 1, 0);
	glRotated(rotation.Z, 0, 0, 1);

	//Front
	glBindTexture(GL_TEXTURE_2D, texture.TextureTable[0]);
	glBegin(GL_QUADS);
	glNormal3f(0.0f, 0.0f, 1.0f);

	glTexCoord2f(0, 0);
	glVertex3f(x - dimension.A / 2, y - dimension.B / 2, z + dimension.C / 2);

	glTexCoord2f(1, 0);
	glVertex3f(x + dimension.A / 2, y - dimension.B / 2, z + dimension.C / 2);

	glTexCoord2f(1, 1);
	glVertex3f(x + dimension.A / 2, y + dimension.B / 2, z + dimension.C / 2);

	glTexCoord2f(0, 1);
	glVertex3f(x - dimension.A / 2, y + dimension.B / 2, z + dimension.C / 2);

	glEnd();

	//Left
	glBindTexture(GL_TEXTURE_2D, texture.TextureTable[1]);
	glBegin(GL_QUADS);
	glNormal3f(-1.0f, 0.0f, 0.0f);

	glTexCoord2f(0, 0);
	glVertex3f(x - dimension.A / 2, y - dimension.B / 2, z - dimension.C / 2);

	glTexCoord2f(1, 0);
	glVertex3f(x - dimension.A / 2, y - dimension.B / 2, z + dimension.C / 2);

	glTexCoord2f(1, 1);
	glVertex3f(x - dimension.A / 2, y + dimension.B / 2, z + dimension.C / 2);

	glTexCoord2f(0, 1);
	glVertex3f(x - dimension.A / 2, y + dimension.B / 2, z - dimension.C / 2);

	glEnd();

	//Back
	glBindTexture(GL_TEXTURE_2D, texture.TextureTable[2]);
	glBegin(GL_QUADS);
	glNormal3f(0.0f, 0.0f, -1.0f);

	glTexCoord2f(0, 0);
	glVertex3f(x + dimension.A / 2, y - dimension.B / 2, z - dimension.C / 2);

	glTexCoord2f(1, 0);
	glVertex3f(x - dimension.A / 2, y - dimension.B / 2, z - dimension.C / 2);

	glTexCoord2f(1, 1);
	glVertex3f(x - dimension.A / 2, y + dimension.B / 2, z - dimension.C / 2);

	glTexCoord2f(0, 1);
	glVertex3f(x + dimension.A / 2, y + dimension.B / 2, z - dimension.C / 2);

	glEnd();

	//Right
	glBindTexture(GL_TEXTURE_2D, texture.TextureTable[3]);
	glBegin(GL_QUADS);
	glNormal3f(1.0f, 0.0f, 0.0f);

	glTexCoord2f(0, 0);
	glVertex3f(x + dimension.A / 2, y - dimension.B / 2, z + dimension.C / 2);

	glTexCoord2f(1, 0);
	glVertex3f(x + dimension.A / 2, y - dimension.B / 2, z - dimension.C / 2);

	glTexCoord2f(1, 1);
	glVertex3f(x + dimension.A / 2, y + dimension.B / 2, z - dimension.C / 2);

	glTexCoord2f(0, 1);
	glVertex3f(x + dimension.A / 2, y + dimension.B / 2, z + dimension.C / 2);

	glEnd();

	//Down
	glBindTexture(GL_TEXTURE_2D, texture.TextureTable[4]);
	glBegin(GL_QUADS);
	glNormal3f(0.0f, -1.0f, 0.0f);

	glTexCoord2f(0, 0);
	glVertex3f(x - dimension.A / 2, y - dimension.B / 2, z - dimension.C / 2);

	glTexCoord2f(1, 0);
	glVertex3f(x + dimension.A / 2, y - dimension.B / 2, z - dimension.C / 2);

	glTexCoord2f(1, 1);
	glVertex3f(x + dimension.A / 2, y - dimension.B / 2, z + dimension.C / 2);

	glTexCoord2f(0, 1);
	glVertex3f(x - dimension.A / 2, y - dimension.B / 2, z + dimension.C / 2);

	glEnd();

	//Up
	glBindTexture(GL_TEXTURE_2D, texture.TextureTable[5]);
	glBegin(GL_QUADS);
	glNormal3f(0.0f, 1.0f, 0.0f);

	glTexCoord2f(0, 0);
	glVertex3f(x - dimension.A / 2, y + dimension.B / 2, z + dimension.C / 2);

	glTexCoord2f(1, 0);
	glVertex3f(x + dimension.A / 2, y + dimension.B / 2, z + dimension.C / 2);

	glTexCoord2f(1, 1);
	glVertex3f(x + dimension.A / 2, y + dimension.B / 2, z - dimension.C / 2);

	glTexCoord2f(0, 1);
	glVertex3f(x - dimension.A / 2, y + dimension.B / 2, z - dimension.C / 2);

	glEnd();

	glPopMatrix();
}


static void display(void)
{
	RenderCamera();
	RenderLight();

	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glColor3d(1, 1, 1);

	// Karmnik
	glPushMatrix();

	glTranslated(globalPosition.X, globalPosition.Y, globalPosition.Z);
	glRotated(globalRotation.X, 1, 0, 0);
	glRotated(globalRotation.Y, 0, 1, 0);
	glRotated(globalRotation.Z, 0, 0, 1);

	//Base
	RenderCuboid(Position(0, 0, 0), Dimensions(3, 4, 0.3), Rotation(90, 0, 0), *woodTexture3);

	//Sides
	RenderCuboid(Position(1.35, 0.4, 0), Dimensions(0.3, 3.4, 0.5), Rotation(90, 0, 0), *woodTexture1);
	RenderCuboid(Position(-1.35, 0.4, 0), Dimensions(0.3, 3.4, 0.5), Rotation(90, 0, 0), *woodTexture1);
	RenderCuboid(Position(0, 0.4, 1.85), Dimensions(0.3, 3, 0.5), Rotation(90, 0, 90), *woodTexture1);
	RenderCuboid(Position(0, 0.4, -1.85), Dimensions(0.3, 3, 0.5), Rotation(90, 0, 90), *woodTexture1);

	//Bars
	RenderCuboid(Position(-1, 1.45, 1.5), Dimensions(0.4, 2.6, 0.4), Rotation(0, 0, 0), *woodTexture1);
	RenderCuboid(Position(-1, 1.45, -1.5), Dimensions(0.4, 2.6, 0.4), Rotation(0, 0, 0), *woodTexture1);
	RenderCuboid(Position(1, 1.45, -1.5), Dimensions(0.4, 2.6, 0.4), Rotation(0, 0, 0), *woodTexture1);
	RenderCuboid(Position(1, 1.45, 1.5), Dimensions(0.4, 2.6, 0.4), Rotation(0, 0, 0), *woodTexture1);

	//Roof
	RenderCuboid(Position(-0.78, 3, 0), Dimensions(2.5, 4, 0.3), Rotation(90, 45, 0), *woodTexture2);
	RenderCuboid(Position(0.78, 3, 0), Dimensions(2.5, 3.99999, 0.3), Rotation(90, -45, 0), *woodTexture2);

	//Brackets
	RenderCuboid(Position(0, 2.5, 1.5), Dimensions(0.3, 1.6, 0.4), Rotation(0, 0, 90), *woodTexture1);
	RenderCuboid(Position(0, 2.5, -1.5), Dimensions(0.3, 1.6, 0.4), Rotation(0, 0, 90), *woodTexture1);

	glPopMatrix();

	//Bird
	glPushMatrix();
	glColor3d(0, 0, 1);
	glTranslated(-1, 4.4, 4);
	glRotated(90, 0, 1, 0);
	//Body
	RenderCuboid(Position(0, 0, 0), Dimensions(0.5, 1, 0.5), Rotation(15, 0, 0), NULL);
	//Head
	RenderCuboid(Position(0, 0.8, 0.2), Dimensions(0.5, 0.5, 0.5), Rotation(0, 0, 0), NULL);
	//Wings
	RenderCuboid(Position(-0.4, 0.1, 0), Dimensions(0.1, 1, 0.5), Rotation(20, 0, -20), NULL);
	RenderCuboid(Position(0.4, 0.1, 0), Dimensions(0.1, 1, 0.5), Rotation(20, 0, 20), NULL);
	//Tail
	RenderCuboid(Position(0, -0.4, -0.5), Dimensions(0.5, 0.5, 0.1), Rotation(80, 0, 0), NULL);

	glPopMatrix();


	//Tree
	glPushMatrix();
	glColor3d(1, 1, 1);
	glTranslated(-1, 0, 0);
	//Log
	RenderCuboid(Position(0, 2, 0), Dimensions(2, 10, 2), Rotation(0, 0, 0), *logTexture);
	//Leaf
	RenderCuboid(Position(0, 8, 0), Dimensions(4, 4, 4), Rotation(0, 0, 0), *leafTexture);
	//Branch
	RenderCuboid(Position(3, 5, 0), Dimensions(0.7, 4, 0.7), Rotation(0, 0, 90), *logTexture);
	RenderCuboid(Position(0, 4, 3), Dimensions(0.4, 4, 0.4), Rotation(90, 0, 0), *logTexture);

	glPopMatrix();

	glutSwapBuffers();
}

static void key(unsigned char key, int x, int y)
{
	switch (key)
	{
	case 27:
		exit(0);
		break;

	case 'z':
		globalPosition.X += 0.2;
		break;
	case 'x':
		globalPosition.X -= 0.2;
		break;
	case 'c':
		globalPosition.Y -= 0.2;
		break;
	case 'v':
		globalPosition.Y += 0.2;
		break;
	case 'b':
		globalPosition.Z -= 0.2;
		break;
	case 'n':
		globalPosition.Z += 0.2;
		break;

	case 'a':
		globalRotation.X += 5.0;
		break;
	case 's':
		globalRotation.X -= 5.0;
		break;
	case 'd':
		globalRotation.Y += 5.0;
		break;
	case 'f':
		globalRotation.Y -= 5.0;
		break;
	case 'g':
		globalRotation.Z += 5.0;
		break;
	case 'h':
		globalRotation.Z -= 5.0;
		break;

	case '1':
		if (light)
			glDisable(GL_LIGHTING);
		else
			glEnable(GL_LIGHTING);
		light = !light;
		break;
	case '2':
		if (light0)
			glDisable(GL_LIGHT0);
		else
			glEnable(GL_LIGHT0);
		light0 = !light0;
		break;
	case '3':
		if (light1)
			glDisable(GL_LIGHT1);
		else
			glEnable(GL_LIGHT1);
		light1 = !light1;
		break;

	case '+':
		lightIntensity += 0.05;
		if (lightIntensity > 1.0)
			lightIntensity = 1.0;
		break;
	case '-':
		lightIntensity -= 0.05;
		if (lightIntensity < 0.0)
			lightIntensity = 0.0;
		break;

	case 'q':
		lightsRotation += 3.0;
		break;
	case 'w':
		lightsRotation -= 3.0;
		break;

	}
	glutPostRedisplay();
}

void Menu(int value)
{
	switch (value)
	{
	case 1:
		currentCamera = CameraType::PERSP;
		break;
	case 2:
		currentCamera = CameraType::ORTO;
		break;
	}
}

void MouseButton(int button, int state, int x, int y)
{
	if (state == GLUT_DOWN)
	{
		mouseX = x;
		mouseY = y;
		if (button == 0)
			rotateCamera = true;
	}
	else
		rotateCamera = false;

	if (button == 3)
		cameraPostiton.distance -= 1;
	else if (button == 4)
		cameraPostiton.distance += 1;
}

void Motion(int x, int y)
{
	int tx = x - mouseX;
	int ty = y - mouseY;
	mouseX = x;
	mouseY = y;

	if (rotateCamera) {
		double sensitivity = 0.01;
		cameraPostiton.horizontalAngle += tx * sensitivity;
		cameraPostiton.verticalAngle += ty * sensitivity;
	}
}

static void idle(void)
{
	glutPostRedisplay();
}

const GLfloat mat_ambient[] = { 0.0f, 0.0f, 0.0f, 1.0f };
const GLfloat mat_diffuse[] = { 0.8f, 0.8f, 0.8f, 1.0f };
const GLfloat mat_specular[] = { 1.0f, 1.0f, 1.0f, 1.0f };
const GLfloat high_shininess[] = { 100.0f };

/* Program entry point */

int main(int argc, char* argv[])
{
	glutInit(&argc, argv);
	glutInitWindowSize(800, 600);
	glutInitWindowPosition(10, 10);
	glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE | GLUT_DEPTH);

	glutCreateWindow("Karmnik - Piotr Krupa");

	glutReshapeFunc(resize);
	glutDisplayFunc(display);
	glutKeyboardFunc(key);
	glutIdleFunc(idle);
	glutMouseFunc(MouseButton);
	glutMotionFunc(Motion);

	glutCreateMenu(Menu);
	glutAddMenuEntry("Rzutowanie perspective", 1);
	glutAddMenuEntry("Rzutowanie ortogonalne", 2);
	glutAttachMenu(GLUT_RIGHT_BUTTON);

	glClearColor(0, 0, 0, 1);
	glEnable(GL_CULL_FACE);
	glCullFace(GL_BACK);

	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LESS);

	glEnable(GL_TEXTURE_2D);
	glGenTextures(liczbaTekstur, obiektyTextur);
	glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_MODULATE);

	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);

	glEnable(GL_LIGHT0);
	glEnable(GL_LIGHT1);
	glEnable(GL_NORMALIZE);
	glEnable(GL_COLOR_MATERIAL);
	glEnable(GL_LIGHTING);

	glMaterialfv(GL_FRONT, GL_AMBIENT, mat_ambient);
	glMaterialfv(GL_FRONT, GL_DIFFUSE, mat_diffuse);
	glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
	glMaterialfv(GL_FRONT, GL_SHININESS, high_shininess);

	for (int i = 0; i < liczbaTekstur; i++)
	{
		GLubyte* pBytes;
		GLint iWidth, iHeight, iComponents;
		GLenum eFormat;
		glBindTexture(GL_TEXTURE_2D, obiektyTextur[i]); // dowi¹zanie obiektów tekstur
		pBytes = glploadtga(plikiTextur[i], &iWidth, &iHeight, &iComponents, &eFormat); // Za³adowanie tekstur
		// utworzenie mipmap
		gluBuild2DMipmaps(GL_TEXTURE_2D, iComponents, iWidth, iHeight, eFormat, GL_UNSIGNED_BYTE, pBytes);
		free(pBytes); // zwolnienie pamiêci
	}

	woodTexture1 = new Texture(obiektyTextur[0]);
	woodTexture2 = new Texture(obiektyTextur[0], obiektyTextur[1], obiektyTextur[1], obiektyTextur[1], obiektyTextur[0], obiektyTextur[0]);
	woodTexture3 = new Texture(obiektyTextur[1]);
	leafTexture = new Texture(obiektyTextur[2]);
	logTexture = new Texture(obiektyTextur[3], obiektyTextur[3], obiektyTextur[3], obiektyTextur[3], obiektyTextur[0], obiektyTextur[0]);

	glutMainLoop();

	delete woodTexture1;
	delete woodTexture2;
	delete woodTexture3;
	delete leafTexture;
	delete logTexture;
	return EXIT_SUCCESS;
}
