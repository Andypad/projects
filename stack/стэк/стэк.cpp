// стэк.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <conio.h>
#include <Windows.h>
#include <string>
#include <vector>


using namespace std;
const int maxSize = 5;

void menu(vector<string>);
void show(vector<string>);
void add(vector<string>&);
void del(vector<string>&);
void delAll(vector<string>&);
void swap(vector<string>&);

void main()
{
	setlocale(0, "");
	vector<string> stack;
	menu(stack);
}
void menu(vector<string> stack)
{
	system("cls");
	cout << "1. Show the stack\n";
	cout << "2. Add an element\n";
	cout << "3. Delete an element\n";
	cout << "4. Delete stack\n";
	cout << "5. Swap the top 2 elements\n";
	cout << "6. Exit\n";
	switch (_getch())
	{
	case '1':
		show(stack);
		break;
	case '2':
		add(stack);
		break;
	case '3':
		del(stack);
		break;
	case '4':
		delAll(stack);
		break;
	case '5':
		swap(stack);
		break;
	case '6':
		exit(0);
	default:
	{
		cout << "Incorrect input\n";
		Sleep(500);
		menu(stack);
	}
	}
}
void show(vector<string> stack)
{
	if (stack.empty())
	{
		cout << "No elements in stack";
		Sleep(500);
		menu(stack);
	}
	system("cls");
	for (int i = stack.size() - 1; i >= 0; i--)
		cout << stack[i] << endl;
	_getch();
	menu(stack);
}
void add(vector<string> &stack)
{
	if (stack.size() == maxSize)
	{
		cout << "Stack is full\n";
		Sleep(500);
		menu(stack);
	}
	system("cls");
	string x;
	cout << "Enter new element\n";
	cin >> x;
	stack.push_back(x);
	menu(stack);
}
void del(vector<string> &stack)
{
	if (stack.empty())
	{
		cout << "No elements in stack";
		Sleep(500);
		menu(stack);
	}
	stack.pop_back();
	menu(stack);
}
void delAll(vector<string> &stack)
{
	if (stack.empty())
	{
		cout << "No elements in stack";
		Sleep(500);
		menu(stack);
	}
	stack.clear();
	menu(stack);
}
void swap(vector<string> &stack)
{
	if (stack.empty() || stack.size() < 2)
	{
		cout << "Not enough elements in stack";
		Sleep(500);
		menu(stack);
	}
	swap(stack[stack.size() - 1], stack[stack.size() - 2]);
	menu(stack);
}

