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

static int slices = 16;
static int stacks = 16;

GLfloat light_ambient1[]  = { 0.0f, 0.0f, 0.0f, 1.0f };
GLfloat light_diffuse1[]  = { 1.0f, 1.0f, 1.0f, 1.0f };
GLfloat light_specular1[] = { 1.0f, 1.0f, 1.0f, 1.0f };
GLfloat light_position1[] = { 2.0f, 5.0f, 5.0f, 0.0f };

GLfloat light_ambient2[]  = { 1.0f, 0.0f, 0.0f, 1.0f };
GLfloat light_diffuse2[]  = { 1.0f, 1.0f, 1.0f, 1.0f };
GLfloat light_specular2[] = { 1.0f, 1.0f, 1.0f, 1.0f };
GLfloat light_position2[] = { -20.0f, 1.0f, -6.0f, 0.0f };
GLfloat light_direction[] = { 1.0f, 0.0f, 0.0f, 1.0f };

float cutoff = 17.0f;

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

    glPushMatrix();
        glTranslated(light_position2[0], light_position2[1], light_position2[2]);
        glutSolidCube(0.5);
    glPopMatrix();

    glPushMatrix();
        glTranslated(0,1,-6);
        glRotated(0,1,1,0);
        glRotated(a,0,a/2,0);
        glutSolidTeapot(1);
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

static void lightning(unsigned char key, int x, int y)
{
    switch (key)
    {
        case 'w':

            break;
        case 'a':

            break;
        case 's':

            break;
        case 'd':

            break;

        case 'b':
            glEnable(GL_LIGHTING);
            break;
        case 'n':
            glDisable(GL_LIGHTING);
            break;


        case 'z':
            glEnable(GL_LIGHT0);
            break;
        case 'x':
            glDisable(GL_LIGHT0);
            break;
        case 'c':
            glEnable(GL_LIGHT1);
            break;
        case 'v':
            glDisable(GL_LIGHT1);
            break;
    }

    glutPostRedisplay();
}
static void idle(void)
{
    glutPostRedisplay();
}

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
    glutKeyboardFunc(lightning);
    glutIdleFunc(idle);

    glClearColor(1,1,1,1);
    //glEnable(GL_CULL_FACE);
    //glCullFace(GL_BACK);

    glEnable(GL_DEPTH_TEST);
    glDepthFunc(GL_LESS);


    glEnable(GL_NORMALIZE);
    glEnable(GL_COLOR_MATERIAL);
    glEnable(GL_LIGHTING);

    glEnable(GL_LIGHT0);
    glLightfv(GL_LIGHT0, GL_AMBIENT,  light_ambient1);
    glLightfv(GL_LIGHT0, GL_DIFFUSE,  light_diffuse1);
    glLightfv(GL_LIGHT0, GL_SPECULAR, light_specular1);
    glLightfv(GL_LIGHT0, GL_POSITION, light_position1);

    glEnable(GL_LIGHT1);
    glLightf(GL_LIGHT1,GL_SPOT_CUTOFF, cutoff);
    glLightf(GL_LIGHT1,GL_SPOT_EXPONENT, 1.0f);

    glLightfv(GL_LIGHT1, GL_AMBIENT,  light_ambient2);
    glLightfv(GL_LIGHT1, GL_DIFFUSE,  light_diffuse2);
    glLightfv(GL_LIGHT1, GL_SPECULAR, light_specular2);
    glLightfv(GL_LIGHT1, GL_POSITION, light_position2);
    glLightfv(GL_LIGHT1,GL_SPOT_DIRECTION, light_direction);



    glMaterialfv(GL_FRONT, GL_AMBIENT,   mat_ambient);
    glMaterialfv(GL_FRONT, GL_DIFFUSE,   mat_diffuse);
    glMaterialfv(GL_FRONT, GL_SPECULAR,  mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, high_shininess);

    glutMainLoop();

    return EXIT_SUCCESS;
}
