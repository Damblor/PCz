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

#include<cmath>

#define GL_PI 3.1415f

static int slices = 16;
static int stacks = 16;

static int ax = 0;
static int ay = 0;

enum
{
 EXIT,
 FULL_WINDOW,
 ASPECT_1_1,
 ORTO,
 FRUST,
 PERSP
};
// ustawienie wartoœci startowych
GLint skala=FULL_WINDOW;
GLint rzut=ORTO;
GLdouble fovy = 90;
// ustawienie parametrów zakresu rzutni
GLdouble aspect = 1;
GLfloat zakres = 150.0f;
GLfloat blisko = 1.0f;
GLfloat daleko = 150.0f;


/* GLUT callback Handlers */

static void resize(int width, int height)
{
    const float ar = (float) width / (float) height;

    glViewport(0, 0, width, height);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    if (rzut==ORTO)
    {
        if (skala==ASPECT_1_1)
        {
            if (width < height && width > 0)
                glOrtho (-zakres,zakres,-zakres*height/width,zakres*height/width,-zakres,zakres);
            else
                if (width >= height && height > 0)
                    glOrtho (-zakres*width/height,zakres*width/height,-zakres,zakres,-zakres,zakres);
        }
        else
            glOrtho (-zakres,zakres,-zakres,zakres,-zakres,zakres);
    }

    if (rzut==FRUST)
    {
        if (skala==ASPECT_1_1)
        {
            if (width < height && width > 0)
                glFrustum (-zakres,zakres,-zakres*height/width,zakres*height/width,blisko,daleko);
            else
                if (width >= height && height > 0)
                    glFrustum (-zakres*width/height,zakres*width/height,-zakres,zakres,blisko,daleko);
        }
        else
        glFrustum (-zakres,zakres,-zakres,zakres,blisko,daleko);
    }


    if (rzut==PERSP)
    {
        if (height > 0)
            aspect = width/(GLdouble)height;
        gluPerspective (fovy,aspect,blisko,daleko);
    }

    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity() ;
}

static void display(void)
{
    const double t = glutGet(GLUT_ELAPSED_TIME) / 1000.0;
    const double a = t*90.0;

    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    //glColor3d(1,0,0);

    GLfloat x,y,angle; // Przechowuj¹ wartoœci wspó³rzêdnych i k¹ta
    int iPivot = 1; // Do oznaczania zamiennych kolorów

    glPushMatrix();
        glTranslatef(0,0,-100);
        glRotated(ax,1,0,0);
        glRotated(ay,0,1,0);
        glBegin(GL_TRIANGLE_FAN); // Rysowanie œciany bocznej sto¿ka
            glVertex3f(0.0f, 0.0f, 75.0f); // Czubek sto¿ka jest wspólnym wierzcho³kiem wszystkich trójk¹tów z wachlarza.
            for(angle = 0.0f; angle < (2.0f*GL_PI); angle += (GL_PI/8.0f))
            {
                x = 50.0f*sin(angle); // Wyliczenie wspó³rzêdnych x i y kolejnego wierzcho³ka
                y = 50.0f*cos(angle);
                if((iPivot %2) == 0) // Wybieranie koloru - zielony lub czerwony
                    glColor3f(0.0f, 1.0f, 0.0f);
                else
                    glColor3f(1.0f, 0.0f, 0.0f);
                iPivot++; // Inkrementacja zmiennej okreœlaj¹cej rodzaj koloru
                // Definiowanie kolejnego wierzcho³ka w wachlarzu trójk¹tów
                glVertex2f(x, y);
            }
         glEnd(); // Zakoñczenie rysowania trójk¹tów sto¿ka
         glBegin(GL_TRIANGLE_FAN); // Rozpoczêcie rysowania kolejnego wachlarza trójk¹tów zakrywaj¹cego podstawê sto¿ka
            glVertex2f(0.0f, 0.0f); // Œrodek wachlarza znajduje siê na pocz¹tku uk³adu wspó³rzêdnych
            for(angle = 0.0f; angle < (2.0f*GL_PI); angle += (GL_PI/8.0f))
            {
                x = 50.0f*sin(angle); // Wyliczenie wspó³rzêdnych x i y kolejnego wierzcho³ka
                y = 50.0f*cos(angle);
                if((iPivot %2) == 0) // Wybieranie koloru - zielony lub czerwony
                    glColor3f(0.0f, 1.0f, 0.0f);
                else
                    glColor3f(1.0f, 0.0f, 0.0f);
                iPivot++; // Inkrementacja zmiennej okreœlaj¹cej rodzaj koloru
                glVertex2f(x, y); // Definiowanie kolejnego wierzcho³ka w wachlarzu trójk¹tów
            }
        glEnd(); // Zakoñczenie rysowania trójk¹tów podstawy sto¿ka
    glPopMatrix();

    glutSwapBuffers();
}

void Menu (int value)
{
    switch (value)
    {
        // wyjœcie
        case EXIT:
        exit (0);
        case FULL_WINDOW:
        skala=FULL_WINDOW;
        resize (glutGet (GLUT_WINDOW_WIDTH),glutGet (GLUT_WINDOW_HEIGHT));
        break;
        case ASPECT_1_1:
        skala=ASPECT_1_1;
        resize (glutGet (GLUT_WINDOW_WIDTH),glutGet (GLUT_WINDOW_HEIGHT));
        break;
        case ORTO:
        rzut=ORTO;
        resize (glutGet (GLUT_WINDOW_WIDTH),glutGet (GLUT_WINDOW_HEIGHT));
        break;
        case FRUST:
        rzut=FRUST;
        resize (glutGet (GLUT_WINDOW_WIDTH),glutGet (GLUT_WINDOW_HEIGHT));
        break;
        case PERSP:
        rzut=PERSP;
        resize (glutGet (GLUT_WINDOW_WIDTH),glutGet (GLUT_WINDOW_HEIGHT));
        break;
    }
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
        case 'z':
            ax += 10;
            break;
        case 'x':
            ax -= 10;
            break;
        case 'c':
            ay += 10;
            break;
        case 'v':
            ay -= 10;
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

    glutCreateMenu(Menu);
    glutAddMenuEntry ("Rodzaj skalowania - cale okno", FULL_WINDOW);
    glutAddMenuEntry ("Rodzaj skalowania - skala 1:1", ASPECT_1_1);
    glutAddMenuEntry ("Rzutowanie ortogonalne", ORTO);
    glutAddMenuEntry ("Rzutowanie frustum", FRUST);
    glutAddMenuEntry ("Rzutowanie perspective", PERSP);
    glutAddMenuEntry ("Wyjscie",EXIT);
    glutAttachMenu (GLUT_RIGHT_BUTTON);

    glClearColor(1,1,1,1);
    //glEnable(GL_CULL_FACE);
    //glCullFace(GL_BACK);

    glEnable(GL_DEPTH_TEST);
    glDepthFunc(GL_LESS);

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

    glFrontFace(GL_CW);

    glutMainLoop();

    return EXIT_SUCCESS;
}
