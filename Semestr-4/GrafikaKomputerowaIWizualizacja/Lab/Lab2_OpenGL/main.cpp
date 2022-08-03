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

#include <iostream>
#include <stdlib.h>
#include <fstream>

using namespace std;

static int slices = 16;
static int stacks = 16;
static int lw, lk;

const int kolumny = 1339, wiersze = 2000;
int Rs[kolumny][wiersze];
int Gs[kolumny][wiersze];
int Bs[kolumny][wiersze];

int Rn[kolumny][wiersze];
int Gn[kolumny][wiersze];
int Bn[kolumny][wiersze];

int Mdp[3][3] = {1,1,1,
                1,1,1,
                1,1,1};

int Mgp[3][3] = {-1,-1,-1,
                -1,9,-1,
                -1,-1,-1};

int Mr[3][3] = {0,-1,0,
                -1,5,-1,
                0,-1,0};

int Ms1[3][3] = {1,2,1,
                0,0,0,
                -1,2,-1};

/* GLUT callback Handlers */

static void resize(int width, int height)
{
    const float ar = (float) width / (float) height;

    glViewport(0, 0, width, height);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    //glFrustum(-ar, ar, -1.0, 1.0, 2.0, 100.0);
    glOrtho(0,wiersze,0,kolumny,-10,10);
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity() ;
}

static void display(void)
{
    const double t = glutGet(GLUT_ELAPSED_TIME) / 1000.0;
    const double a = t*90.0;

    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

    glPushMatrix();
        glTranslated(0,0,-6);
        glPointSize(1.0);
        glBegin(GL_POINTS);
        for(int i = 0; i < lk; ++i)
        {
            for(int j = 0; j < lw; ++j)
            {
                glColor3f(Rn[i][j]/255.,Gn[i][j]/255.,Bn[i][j]/255.);
                glVertex3f(j,i,0);

            }
        }
        glEnd();
    glPopMatrix();

    glutSwapBuffers();
}


static void key(unsigned char key, int x, int y)
{
    switch (key)
    {
        case ',':
            exit(0);
            break;

        case '+':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Rn[i][j] -= 30;
                    Gn[i][j] -= 30;
                    Bn[i][j] -= 30;
                }
            }
            break;

        case '-':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Rn[i][j] += 30;
                    Gn[i][j] += 30;
                    Bn[i][j] += 30;
                }
            }
            break;
        case 'z':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Rn[i][j] -= 30;
                }
            }
            break;
        case 'x':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Rn[i][j] += 30;
                }
            }
            break;
        case 'c':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Gn[i][j] -= 30;
                }
            }
            break;
        case 'v':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Gn[i][j] += 30;
                }
            }
            break;
        case 'b':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Bn[i][j] -= 30;
                }
            }
            break;
        case 'n':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Bn[i][j] += 30;
                }
            }
            break;
        case 'a':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Gn[i][j] = 0;
                    Bn[i][j] = 0;
                }
            }
            break;
        case 's':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Gn[i][j] = Gs[i][j];
                    Bn[i][j] = Bs[i][j];
                }
            }
            break;
        case 'd':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Rn[i][j] = 0;
                    Bn[i][j] = 0;
                }
            }
            break;
        case 'f':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Rn[i][j] = Rs[i][j];
                    Bn[i][j] = Bs[i][j];
                }
            }
            break;
        case 'g':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Rn[i][j] = 0;
                    Gn[i][j] = 0;
                }
            }
            break;
        case 'h':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Rn[i][j] = Rs[i][j];
                    Gn[i][j] = Gs[i][j];
                }
            }
            break;


        case '.':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Rn[i][j] = Rs[i][j];
                    Gn[i][j] = Gs[i][j];
                    Bn[i][j] = Bs[i][j];
                }
            }
            break;
        case 'q':
            for(int i = 1; i < lk -1; ++i)
            {
                for(int j = 1; j < lw -1; ++j)
                {
                    Rn[i][j] =
                    (Mdp[0][0] * Rn[i-1][j-1] +
                     Mdp[0][1] * Rn[i-1][j] +
                     Mdp[0][2] * Rn[i-1][j+1] +
                     Mdp[1][0] * Rn[i][j-1] +
                     Mdp[1][1] * Rn[i][j] +
                     Mdp[1][2] * Rn[i][j+1] +
                     Mdp[2][0] * Rn[i+1][j-1] +
                     Mdp[2][1] * Rn[i+1][j] +
                     Mdp[2][2] * Rn[i+1][j+1]) /
                     (Mdp[0][0] + Mdp[0][1] + Mdp[0][2] +
                      Mdp[1][0] + Mdp[1][1] + Mdp[1][2] +
                      Mdp[2][0] + Mdp[2][1] + Mdp[2][2]);

                    Gn[i][j] =
                    (Mdp[0][0] * Gn[i-1][j-1] +
                     Mdp[0][1] * Gn[i-1][j] +
                     Mdp[0][2] * Gn[i-1][j+1] +
                     Mdp[1][0] * Gn[i][j-1] +
                     Mdp[1][1] * Gn[i][j] +
                     Mdp[1][2] * Gn[i][j+1] +
                     Mdp[2][0] * Gn[i+1][j-1] +
                     Mdp[2][1] * Gn[i+1][j] +
                     Mdp[2][2] * Gn[i+1][j+1]) /
                     (Mdp[0][0] + Mdp[0][1] + Mdp[0][2] +
                      Mdp[1][0] + Mdp[1][1] + Mdp[1][2] +
                      Mdp[2][0] + Mdp[2][1] + Mdp[2][2]);
                    Bn[i][j] =
                    (Mdp[0][0] * Bn[i-1][j-1] +
                     Mdp[0][1] * Bn[i-1][j] +
                     Mdp[0][2] * Bn[i-1][j+1] +
                     Mdp[1][0] * Bn[i][j-1] +
                     Mdp[1][1] * Bn[i][j] +
                     Mdp[1][2] * Bn[i][j+1] +
                     Mdp[2][0] * Bn[i+1][j-1] +
                     Mdp[2][1] * Bn[i+1][j] +
                     Mdp[2][2] * Bn[i+1][j+1]) /
                     (Mdp[0][0] + Mdp[0][1] + Mdp[0][2] +
                      Mdp[1][0] + Mdp[1][1] + Mdp[1][2] +
                      Mdp[2][0] + Mdp[2][1] + Mdp[2][2]);
                }
            }
            break;
        case 'w':
            for(int i = 1; i < lk -1; ++i)
            {
                for(int j = 1; j < lw -1; ++j)
                {
                    int k1 = 0;
                    if(Rs[i-1][j-1] > k1)
                        k1 = Rs[i-1][j-1];
                    if(Rs[i-1][j] > k1)
                        k1 = Rs[i-1][j];
                    if(Rs[i-1][j+1] > k1)
                        k1 = Rs[i-1][j+1];
                    if(Rs[i][j-1] > k1)
                        k1 = Rs[i][j-1];
                    if(Rs[i][j] > k1)
                        k1 = Rs[i][j];
                    if(Rs[i][j+1] > k1)
                        k1 = Rs[i][j+1];
                    if(Rs[i+1][j-1] > k1)
                        k1 = Rs[i+1][j-1];
                    if(Rs[i+1][j] > k1)
                        k1 = Rs[i+1][j];
                    if(Rs[i+1][j+1] > k1)
                        k1 = Rs[i+1][j+1];
                    Rn[i][j] = k1;

                    int k2 = 0;
                    if(Gs[i-1][j-1] > k2)
                        k2 = Gs[i-1][j-1];
                    if(Gs[i-1][j] > k2)
                        k2 = Gs[i-1][j];
                    if(Gs[i-1][j+1] > k2)
                        k2 = Gs[i-1][j+1];
                    if(Gs[i][j-1] > k2)
                        k2 = Gs[i][j-1];
                    if(Gs[i][j] > k2)
                        k2 = Gs[i][j];
                    if(Gs[i][j+1] > k2)
                        k2 = Gs[i][j+1];
                    if(Gs[i+1][j-1] > k2)
                        k2 = Gs[i+1][j-1];
                    if(Gs[i+1][j] > k2)
                        k2 = Gs[i+1][j];
                    if(Gs[i+1][j+1] > k2)
                        k2 = Gs[i+1][j+1];
                    Gn[i][j] = k2;

                    int k3 = 0;
                    if(Bs[i-1][j-1] > k3)
                        k3 = Bs[i-1][j-1];
                    if(Bs[i-1][j] > k3)
                        k3 = Bs[i-1][j];
                    if(Bs[i-1][j+1] > k3)
                        k3 = Bs[i-1][j+1];
                    if(Bs[i][j-1] > k3)
                        k3 = Bs[i][j-1];
                    if(Bs[i][j] > k3)
                        k3 = Bs[i][j];
                    if(Bs[i][j+1] > k3)
                        k3 = Bs[i][j+1];
                    if(Bs[i+1][j-1] > k3)
                        k3 = Bs[i+1][j-1];
                    if(Bs[i+1][j] > k3)
                        k3 = Bs[i+1][j];
                    if(Bs[i+1][j+1] > k3)
                        k3 = Bs[i+1][j+1];
                    Bn[i][j] = k3;
                }
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
    ifstream plik("zd5.txt");
    plik >> lk >> lw;
    cout << "wiersze = " << lk << " kolumny = " << lw << endl;
    for(int i = 0; i < lk; ++i)
    {
        for(int j = 0; j < lw; ++j)
        {
            plik >> Rs[i][j];
            plik >> Gs[i][j];
            plik >> Bs[i][j];
        }
    }

    for(int i = 0; i < lk; ++i)
    {
        for(int j = 0; j < lw; ++j)
        {
            Rn[i][j] = Rs[i][j];
            Gn[i][j] = Gs[i][j];
            Bn[i][j] = Bs[i][j];
        }
    }
    cout << "Read complete" << endl;
    plik.close();

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
    glEnable(GL_CULL_FACE);
    glCullFace(GL_BACK);

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

    glutMainLoop();

    return EXIT_SUCCESS;
}
