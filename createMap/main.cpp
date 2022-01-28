#include <iostream>
#include <vector>
#include <ctime>
using namespace std;

int rand(int a, int b){
    srand(static_cast<unsigned int>(time(0)));
    return (rand()%(b-a)) + a;
}
int go_to[4][2] = {{-1, 0}, {0, 1}, {1, 0}, {0, -1}};

vector<int> getQueue(int count){
    vector<int> elements(count);
    for(int i=0; i<count; i++){
        elements[i] = i;
    }
    vector<int> ans;
    for(int i=0; i<count; i++){
        int index = rand(0, count-ans.size());
        ans.push_back(elements[index]);
        elements.erase(elements.begin() + index);
    }
    return ans;
}
int getNum(int a, int b){
    a|= 1 << b;
    return a;
}
void dfs(int** map, int n, int nowX, int nowY, int finishX, int finishY, int wasX = -1, int wasY = -1){
    vector<int> go_to_vector = getQueue(4);
    map[nowX][nowY] = 0;
    if (nowX == finishX && nowY == finishY){
        return;
    }
    for(int item : go_to_vector){
        int toX = nowX + go_to[item][0];
        int toY = nowY + go_to[item][1];
        if (toX != wasX || toY != wasY){
            if ((toX < 0) || (toX >= n) || (toY < 0) || (toY >= n) || (wasX != -1) && (map[toX][toY] != -1)){
                map[nowX][nowY] = getNum (map[nowX][nowY], item);
            }
            else{
                dfs(map, n, toX, toY, finishX, finishY, nowX, nowY);
            }
        }
    }
}

int main(){
    int n = 10;
    int** map = new int*[n];
    for(int i=0; i<n; i++){
        map[i] = new int[n];
        for(int j=0; j<n; j++){
            map[i][j] = -1;
        }
    }
    dfs(map, n, 0,0, n-1, n-1);
    for(int i=0; i<n; i++){
        for(int j=0; j<n; j++){
            cout << map[i][j] << " ";
        }
        cout << endl;
    }
}
