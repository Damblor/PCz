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

#include <iostream>
#include <fstream>

using namespace std;

int lWez, lEle;
double** Wez;
int** Ele;
double** kolor;

static int slices = 16;
static int stacks = 16;

/* GLUT callback Handlers */

static void resize(int width, int height)
{
    const float ar = (float)width / (float)height;

    glViewport(0, 0, width, height);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    glFrustum(-ar, ar, -1.0, 1.0, 0.5, 100.0);

    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
}

static void display(void)
{
    const double t = glutGet(GLUT_ELAPSED_TIME) / 1000.0;
    const double a = t * 90.0;

    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

    glPushMatrix();
    glTranslated(0, 0, -3);
    glRotated(a, 0, 1, 1);
    glBegin(GL_TRIANGLES);
    for (int nrEl = 0; nrEl < lEle; nrEl++)
    {
        glColor3d(kolor[nrEl][0], kolor[nrEl][1], kolor[nrEl][2]);
        glVertex3f(Wez[Ele[nrEl][0]][0], Wez[Ele[nrEl][0]][1], Wez[Ele[nrEl][0]][2]);
        glVertex3f(Wez[Ele[nrEl][1]][0], Wez[Ele[nrEl][1]][1], Wez[Ele[nrEl][1]][2]);
        glVertex3f(Wez[Ele[nrEl][2]][0], Wez[Ele[nrEl][2]][1], Wez[Ele[nrEl][2]][2]);
    }
    glEnd();

    glPopMatrix();

    glutSwapBuffers();
}


static void key(unsigned char key, int x, int y)
{
    switch (key)
    {
    case 27:
    case 'q':
        exit(0);
        break;

    case '+':
        slices++;
        stacks++;
        break;

    case '-':
        if (slices > 3 && stacks > 3)
        {
            slices--;
            stacks--;
        }
        break;
    }

    glutPostRedisplay();
}

static void idle(void)
{
    glutPostRedisplay();
}

const GLfloat light_ambient[] = { 0.0f, 0.0f, 0.0f, 1.0f };
const GLfloat light_diffuse[] = { 1.0f, 1.0f, 1.0f, 1.0f };
const GLfloat light_specular[] = { 1.0f, 1.0f, 1.0f, 1.0f };
const GLfloat light_position[] = { 2.0f, 5.0f, 5.0f, 0.0f };

const GLfloat mat_ambient[] = { 0.7f, 0.7f, 0.7f, 1.0f };
const GLfloat mat_diffuse[] = { 0.8f, 0.8f, 0.8f, 1.0f };
const GLfloat mat_specular[] = { 1.0f, 1.0f, 1.0f, 1.0f };
const GLfloat high_shininess[] = { 100.0f };

/* Program entry point */

int main(int argc, char* argv[])
{
    string nazwaPliku = "objekt.txt";
    ifstream plik(nazwaPliku);
    int pom1, pom2;
    plik >> lWez;
    Wez = new double* [lWez];
    for (int i = 0; i < lWez; i++)
        Wez[i] = new double[3];
    for (int i = 0; i < lWez; i++)
        plik >> pom1 >> Wez[i][0] >> Wez[i][1] >> Wez[i][2];
    plik >> lEle;
    Ele = new int* [lEle];
    for (int i = 0; i < lEle; i++)
        Ele[i] = new int[3];
    for (int i = 0; i < lEle; i++)
    {
        plik >> pom1 >> pom1 >> pom1 >> pom1 >> pom1 >> Ele[i][0] >> Ele[i][1] >> Ele[i][2];
        Ele[i][0]--;
        Ele[i][1]--;
        Ele[i][2]--;
    }

    kolor = new double* [lEle];
    for (int i = 0; i < lEle; i++)
    {
        kolor[i] = new double[3];
        kolor[i][0] = rand() % 255 / 255.;
        kolor[i][1] = rand() % 255 / 255.;
        kolor[i][2] = rand() % 255 / 255.;
    }
    cout << "Liczba wezlow liczba elementow: " << lWez << "\t" << lEle;
    plik.close();

    glutInit(&argc, argv);
    glutInitWindowSize(640, 480);
    glutInitWindowPosition(10, 10);
    glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE | GLUT_DEPTH);

    glutCreateWindow("GLUT Shapes");

    glutReshapeFunc(resize);
    glutDisplayFunc(display);
    glutKeyboardFunc(key);
    glutIdleFunc(idle);

    glClearColor(1, 1, 1, 1);
    //glEnable(GL_CULL_FACE);
    //glCullFace(GL_BACK);

    glEnable(GL_DEPTH_TEST);
    glDepthFunc(GL_LESS);

    glEnable(GL_LIGHT0);
    glEnable(GL_NORMALIZE);
    glEnable(GL_COLOR_MATERIAL);
    glEnable(GL_LIGHTING);

    glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient);
    glLightfv(GL_LIGHT0, GL_DIFFUSE, light_diffuse);
    glLightfv(GL_LIGHT0, GL_SPECULAR, light_specular);
    glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glMaterialfv(GL_FRONT, GL_AMBIENT, mat_ambient);
    glMaterialfv(GL_FRONT, GL_DIFFUSE, mat_diffuse);
    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, high_shininess);

    glutMainLoop();

    return EXIT_SUCCESS;
}
