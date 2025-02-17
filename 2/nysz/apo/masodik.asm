
Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX

	; komment
	mov ah, 2 ; karakter kiíratás parancs jelölése
	mov dl, 49 ; 49 = 1 mint karakter decimális ascii táblázatban
	int 21h ; kernel hívás
	mov dl, 32h ; hexadecimális jele h
	int 21h
	mov dl, "3"
	int 21h
Program_Vege:
	mov	ax, 4c00h
	int	21h

Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start
