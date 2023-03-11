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
#include "biblioteka.h"

static int slices = 16;
static int stacks = 16;

#define LICZBA_OB_TEXTUR 4
GLuint obiektyTextur [LICZBA_OB_TEXTUR];
char *plikiTextur[] = {"E:\\Strefa Studenta\\CodeBlock\\krupa_piotr\\Lab7_OpenGL\\assets\\Ocean.tga",
"E:\\Strefa Studenta\\CodeBlock\\krupa_piotr\\Lab7_OpenGL\\assets\\Wood.tga",
 "E:\\Strefa Studenta\\CodeBlock\\krupa_piotr\\Lab7_OpenGL\\assets\\Ziemia.tga",
  "E:\\Strefa Studenta\\CodeBlock\\krupa_piotr\\Lab7_OpenGL\\assets\\Zima.tga"};

/* GLUT callback Handlers */

static void resize(int width, int height)
{
    const float ar = (float) width / (float) height;

    glViewport(0, 0, width, height);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    glFrustum(-ar, ar, -1.0, 1.0, 1.5, 100.0);

    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity() ;
}

static void display(void)
{
    const double t = glutGet(GLUT_ELAPSED_TIME) / 1000.0;
    const double a = t*90.0;

    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    glColor3d(1,1,1);

    //Cube
    glPushMatrix();

        glTranslated(2,2,-6);
        glRotated(60,0,1,0);
        glRotated(a,0.2,1,0);

        //1
        glBindTexture(GL_TEXTURE_2D,obiektyTextur[0]);
        glBegin(GL_QUADS);
        glNormal3f(0.0f,0.0f,1.0f);

        glTexCoord2f(0,0);
        glVertex3f(-1,-1,1);

        glTexCoord2f(1,0);
        glVertex3f(1,-1,1);

        glTexCoord2f(1,1);
        glVertex3f(1,1,1);

        glTexCoord2f(0,1);
        glVertex3f(-1,1,1);

        glEnd();

        //2
        glBindTexture(GL_TEXTURE_2D,obiektyTextur[1]);
        glBegin(GL_QUADS);
        glNormal3f(-1.0f,0.0f,0.0f);

        glTexCoord2f(0,0);
        glVertex3f(-1,-1,-1);

        glTexCoord2f(1,0);
        glVertex3f(-1,-1,1);

        glTexCoord2f(1,1);
        glVertex3f(-1,1,1);

        glTexCoord2f(0,1);
        glVertex3f(-1,1,-1);

        glEnd();

        //3
        glBindTexture(GL_TEXTURE_2D,obiektyTextur[2]);
        glBegin(GL_QUADS);
        glNormal3f(0.0f,0.0f,-1.0f);

        glTexCoord2f(0,0);
        glVertex3f(1,-1,-1);

        glTexCoord2f(1,0);
        glVertex3f(-1,-1,-1);

        glTexCoord2f(1,1);
        glVertex3f(-1,1,-1);

        glTexCoord2f(0,1);
        glVertex3f(1,1,-1);

        glEnd();

        //4
        glBindTexture(GL_TEXTURE_2D,obiektyTextur[3]);
        glBegin(GL_QUADS);
        glNormal3f(1.0f,0.0f,0.0f);

        glTexCoord2f(0,0);
        glVertex3f(1,-1,1);

        glTexCoord2f(1,0);
        glVertex3f(1,-1,-1);

        glTexCoord2f(1,1);
        glVertex3f(1,1,-1);

        glTexCoord2f(0,1);
        glVertex3f(1,1,1);

        glEnd();

    glPopMatrix();


    //Square
    glPushMatrix();

        glTranslated(-2,-2,-6);
        glBindTexture(GL_TEXTURE_2D,obiektyTextur[2]);
        glBegin(GL_QUADS);
        glNormal3f(0.0f,0.0f,1.0f);

        glTexCoord2f(0.4,0.7);
        glVertex3f(-1,-1,1);

        glTexCoord2f(0.7,0.7);
        glVertex3f(1,-1,1);

        glTexCoord2f(0.7,0.9);
        glVertex3f(1,1,1);

        glTexCoord2f(0.4,0.9);
        glVertex3f(-1,1,1);

        glEnd();

    glPopMatrix();

    //Triangle
    glPushMatrix();

        glTranslated(2,-2,-6);

        //1
        glBindTexture(GL_TEXTURE_2D,obiektyTextur[1]);
        glBegin(GL_TRIANGLES);
        glNormal3f(0.0f,0.0f,1.0f);

        glTexCoord2f(1,0);
        glVertex3f(-1,-1,1);

        glTexCoord2f(0,0);
        glVertex3f(1,-1,1);

        glTexCoord2f(0.5,1);
        glVertex3f(0,1,1);


        glEnd();

    glPopMatrix();

    //Blue square
    glPushMatrix();
        glColor3d(0,0,1);
        glTranslated(-2,2,-6);

        //1
        glBindTexture(GL_TEXTURE_2D,obiektyTextur[2]);
        glBegin(GL_QUADS);
        glNormal3f(0.0f,0.0f,1.0f);

        glTexCoord2f(0,0);
        glVertex3f(-1,-1,1);

        glTexCoord2f(1,0);
        glVertex3f(1,-1,1);

        glTexCoord2f(1,1);
        glVertex3f(1,1,1);

        glTexCoord2f(0,1);
        glVertex3f(-1,1,1);

        glEnd();

    glPopMatrix();

    glutSwapBuffers();
}


static void key(unsigned char key, int x, int y)
{
    switch (key)
    {
        case 27 :
        case 'q':
            exit(0);
            break;

        case '+':
            slices++;
            stacks++;
            break;

        case '-':
            if (slices>3 && stacks>3)
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

const GLfloat light_ambient[]  = { 0.0f, 0.0f, 0.0f, 1.0f };
const GLfloat light_diffuse[]  = { 1.0f, 1.0f, 1.0f, 1.0f };
const GLfloat light_specular[] = { 1.0f, 1.0f, 1.0f, 1.0f };
const GLfloat light_position[] = { 2.0f, 5.0f, 5.0f, 0.0f };

const GLfloat mat_ambient[]    = { 0.7f, 0.7f, 0.7f, 1.0f };
const GLfloat mat_diffuse[]    = { 0.8f, 0.8f, 0.8f, 1.0f };
const GLfloat mat_specular[]   = { 1.0f, 1.0f, 1.0f, 1.0f };
const GLfloat high_shininess[] = { 100.0f };

/* Program entry point */

int main(int argc, char *argv[])
{
    glutInit(&argc, argv);
    glutInitWindowSize(640,480);
    glutInitWindowPosition(10,10);
    glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE | GLUT_DEPTH);

    glutCreateWindow("GLUT Shapes");

    glutReshapeFunc(resize);
    glutDisplayFunc(display);
    glutKeyboardFunc(key);
    glutIdleFunc(idle);

    glClearColor(1,1,1,1);
    //glEnable(GL_CULL_FACE);
    glCullFace(GL_BACK);

    glEnable(GL_DEPTH_TEST);
    glDepthFunc(GL_LESS);

    glEnable(GL_TEXTURE_2D); // w³¹czenie teksturowania
    glGenTextures(LICZBA_OB_TEXTUR, obiektyTextur); // wygenerowanie obiektów tekstur
    glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_MODULATE); // ustalenie trybu œrodowiska


    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);



    glEnable(GL_LIGHT0);
    glEnable(GL_NORMALIZE);
    glEnable(GL_COLOR_MATERIAL);
    glEnable(GL_LIGHTING);

    glLightfv(GL_LIGHT0, GL_AMBIENT,  light_ambient);
    glLightfv(GL_LIGHT0, GL_DIFFUSE,  light_diffuse);
    glLightfv(GL_LIGHT0, GL_SPECULAR, light_specular);
    glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glMaterialfv(GL_FRONT, GL_AMBIENT,   mat_ambient);
    glMaterialfv(GL_FRONT, GL_DIFFUSE,   mat_diffuse);
    glMaterialfv(GL_FRONT, GL_SPECULAR,  mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, high_shininess);

    for (int i = 0; i < LICZBA_OB_TEXTUR; i++)
    {
        GLubyte *pBytes;
        GLint iWidth, iHeight, iComponents;
        GLenum eFormat;
        glBindTexture(GL_TEXTURE_2D, obiektyTextur[i]); // dowi¹zanie obiektów tekstur
        pBytes = glploadtga(plikiTextur[i], &iWidth, &iHeight, &iComponents, &eFormat); // Za³adowanie tekstur
        // utworzenie mipmap
        gluBuild2DMipmaps(GL_TEXTURE_2D, iComponents, iWidth, iHeight, eFormat, GL_UNSIGNED_BYTE, pBytes);
        free(pBytes); // zwolnienie pamiêci
    }

    glutMainLoop();

    glDeleteTextures(LICZBA_OB_TEXTUR, obiektyTextur);
    return EXIT_SUCCESS;
}
