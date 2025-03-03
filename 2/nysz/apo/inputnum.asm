
Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX
	
	mov ah, 9 ; string kiírás 
	mov dx, offset msg ; string
	int 21h
	
	mov ah, 0 ; beolvasás
	int 16h ; input figyelő megszakítás
	; a beolvasott karakter már  az al-ben szerepel
	
	mov cl, al ; biztonsági mentés

	mov ah, 2 ; karakter kiírás
	mov dl, al ; dl-be al értékét írja
	int 21h
	
	mov ah, 2
	mov dl, 10
	int 21h
	
	mov ah, 2
	mov dl, 13
	int 21h
	
	mov ah, 9
	mov dx, offset msg1
	int 21h
	
	mov ah, 2 ; karakter kiírás
	mov dl, cl ; dl-be al értékét írja
	int 21h

Program_Vege:
	mov	ax, 4c00h
	int	21h

msg db "Adjon  meg egy szamot 0-9 kozott: $"

msg1 db "Megadott szam: $"

Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start

