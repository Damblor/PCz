#ifdef __APPLE__
#include <GLUT/glut.h>
#else
#include <GL/glut.h>
#endif

#include <iostream>
#include <stdlib.h>
#include <fstream>
#include <cmath>

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

const double gamma = 2.2;

int Mdp[3][3] = { 1,1,1,
                1,1,1,
                1,1,1 };

int Mgp[3][3] = { -1,-1,-1,
                -1,9,-1,
                -1,-1,-1 };

int Msp[3][3] = { 1,2,1,
                0,0,0,
                -1,-2,-1 };

int Muw[3][3] = {-1,1,1,
                -1,-1,1,
                -1,1,1 };



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
        //Przyciemnianie
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
        //Rozjaœnianie
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
        //Zmiana nasycenia kolorami
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
        //Wyodrêbnienie czerwonego
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
        //Wyodrêbnienie zielonego
        case 's':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Rn[i][j] = 0;
                    Bn[i][j] = 0;
                }
            }
            break;
        //Wyodrêbnienie niebieskiego
        case 'd':
            for(int i = 0; i < lk; ++i)
            {
                for(int j = 0; j < lw; ++j)
                {
                    Rn[i][j] = 0;
                    Gn[i][j] = 0;
                }
            }
            break;
        //Gamma
        case 'f':
            for (int i = 0; i < lk; ++i)
            {
                for (int j = 0; j < lw; ++j)
                {
                    Rn[i][j] = pow(Rs[i][j], gamma);
                    Gn[i][j] = pow(Gs[i][j], gamma);
                    Bn[i][j] = pow(Bs[i][j], gamma);
                }
            }
            break;
        //Negatyw
        case 'g':
            for (int i = 0; i < lk; ++i)
            {
                for (int j = 0; j < lw; ++j)
                {
                    Rn[i][j] = 255 - Rs[i][j];
                    Gn[i][j] = 255 - Gs[i][j];
                    Bn[i][j] = 255 - Bs[i][j];
                }
            }
            break;
        //Przywracanie domyœlnego obrazu
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
        //Filtr dolnoprzepustowy uœredniaj¹cy
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
        //Filtr górnoprzepustowy usuwaj¹cy œredni¹
        case 'w':
            for (int i = 1; i < lk - 1; ++i)
            {
                for (int j = 1; j < lw - 1; ++j)
                {
                    Rn[i][j] =
                        (Mgp[0][0] * Rs[i - 1][j - 1] +
                            Mgp[0][1] * Rs[i - 1][j] +
                            Mgp[0][2] * Rs[i - 1][j + 1] +
                            Mgp[1][0] * Rs[i][j - 1] +
                            Mgp[1][1] * Rs[i][j] +
                            Mgp[1][2] * Rs[i][j + 1] +
                            Mgp[2][0] * Rs[i + 1][j - 1] +
                            Mgp[2][1] * Rs[i + 1][j] +
                            Mgp[2][2] * Rs[i + 1][j + 1]) /
                        (Mgp[0][0] + Mgp[0][1] + Mgp[0][2] +
                            Mgp[1][0] + Mgp[1][1] + Mgp[1][2] +
                            Mgp[2][0] + Mgp[2][1] + Mgp[2][2]);

                    Gn[i][j] =
                        (Mgp[0][0] * Gs[i - 1][j - 1] +
                            Mgp[0][1] * Gs[i - 1][j] +
                            Mgp[0][2] * Gs[i - 1][j + 1] +
                            Mgp[1][0] * Gs[i][j - 1] +
                            Mgp[1][1] * Gs[i][j] +
                            Mgp[1][2] * Gs[i][j + 1] +
                            Mgp[2][0] * Gs[i + 1][j - 1] +
                            Mgp[2][1] * Gs[i + 1][j] +
                            Mgp[2][2] * Gs[i + 1][j + 1]) /
                        (Mgp[0][0] + Mgp[0][1] + Mgp[0][2] +
                            Mgp[1][0] + Mgp[1][1] + Mgp[1][2] +
                            Mgp[2][0] + Mgp[2][1] + Mgp[2][2]);
                    Bn[i][j] =
                        (Mgp[0][0] * Bs[i - 1][j - 1] +
                            Mgp[0][1] * Bs[i - 1][j] +
                            Mgp[0][2] * Bs[i - 1][j + 1] +
                            Mgp[1][0] * Bs[i][j - 1] +
                            Mgp[1][1] * Bs[i][j] +
                            Mgp[1][2] * Bs[i][j + 1] +
                            Mgp[2][0] * Bs[i + 1][j - 1] +
                            Mgp[2][1] * Bs[i + 1][j] +
                            Mgp[2][2] * Bs[i + 1][j + 1]) /
                        (Mgp[0][0] + Mgp[0][1] + Mgp[0][2] +
                            Mgp[1][0] + Mgp[1][1] + Mgp[1][2] +
                            Mgp[2][0] + Mgp[2][1] + Mgp[2][2]);
                }
            }
            break;
        //Filtr Sobel'a poziomy
        case 'e':
            for (int i = 1; i < lk - 1; ++i)
            {
                for (int j = 1; j < lw - 1; ++j)
                {
                    Rn[i][j] =
                        (Msp[0][0] * Rs[i - 1][j - 1] +
                            Msp[0][1] * Rs[i - 1][j] +
                            Msp[0][2] * Rs[i - 1][j + 1] +
                            Msp[1][0] * Rs[i][j - 1] +
                            Msp[1][1] * Rs[i][j] +
                            Msp[1][2] * Rs[i][j + 1] +
                            Msp[2][0] * Rs[i + 1][j - 1] +
                            Msp[2][1] * Rs[i + 1][j] +
                            Msp[2][2] * Rs[i + 1][j + 1]);

                    Gn[i][j] =
                        (Msp[0][0] * Gs[i - 1][j - 1] +
                            Msp[0][1] * Gs[i - 1][j] +
                            Msp[0][2] * Gs[i - 1][j + 1] +
                            Msp[1][0] * Gs[i][j - 1] +
                            Msp[1][1] * Gs[i][j] +
                            Msp[1][2] * Gs[i][j + 1] +
                            Msp[2][0] * Gs[i + 1][j - 1] +
                            Msp[2][1] * Gs[i + 1][j] +
                            Msp[2][2] * Gs[i + 1][j + 1]);
                    Bn[i][j] =
                        (Msp[0][0] * Bs[i - 1][j - 1] +
                            Msp[0][1] * Bs[i - 1][j] +
                            Msp[0][2] * Bs[i - 1][j + 1] +
                            Msp[1][0] * Bs[i][j - 1] +
                            Msp[1][1] * Bs[i][j] +
                            Msp[1][2] * Bs[i][j + 1] +
                            Msp[2][0] * Bs[i + 1][j - 1] +
                            Msp[2][1] * Bs[i + 1][j] +
                            Msp[2][2] * Bs[i + 1][j + 1]);
                }
            }
            break;
        //Filtr uwypuklaj¹cy wschód
        case 'r':
            for (int i = 1; i < lk - 1; ++i)
            {
                for (int j = 1; j < lw - 1; ++j)
                {
                    Rn[i][j] =
                        (Muw[0][0] * Rs[i - 1][j - 1] +
                            Muw[0][1] * Rs[i - 1][j] +
                            Muw[0][2] * Rs[i - 1][j + 1] +
                            Muw[1][0] * Rs[i][j - 1] +
                            Muw[1][1] * Rs[i][j] +
                            Muw[1][2] * Rs[i][j + 1] +
                            Muw[2][0] * Rs[i + 1][j - 1] +
                            Muw[2][1] * Rs[i + 1][j] +
                            Muw[2][2] * Rs[i + 1][j + 1]);

                    Gn[i][j] =
                        (Muw[0][0] * Gs[i - 1][j - 1] +
                            Muw[0][1] * Gs[i - 1][j] +
                            Muw[0][2] * Gs[i - 1][j + 1] +
                            Muw[1][0] * Gs[i][j - 1] +
                            Muw[1][1] * Gs[i][j] +
                            Muw[1][2] * Gs[i][j + 1] +
                            Muw[2][0] * Gs[i + 1][j - 1] +
                            Muw[2][1] * Gs[i + 1][j] +
                            Muw[2][2] * Gs[i + 1][j + 1]);
                    Bn[i][j] =
                        (Muw[0][0] * Bs[i - 1][j - 1] +
                            Muw[0][1] * Bs[i - 1][j] +
                            Muw[0][2] * Bs[i - 1][j + 1] +
                            Muw[1][0] * Bs[i][j - 1] +
                            Muw[1][1] * Bs[i][j] +
                            Muw[1][2] * Bs[i][j + 1] +
                            Muw[2][0] * Bs[i + 1][j - 1] +
                            Muw[2][1] * Bs[i + 1][j] +
                            Muw[2][2] * Bs[i + 1][j + 1]);
                }
            }
            break;
        //Filtr maksymalny
        case 't':
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
    //ifstream plik("E:\\Strefa Studenta\\CodeBlock\\krupa_piotr\\Lab2_OpenGL\\zd5.txt");
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
