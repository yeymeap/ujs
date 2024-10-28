import matplotlib.pyplot as plt
import pandas as pd 

stock_prices_file = "tsla_plotly.csv" # csv fájl neve
df = pd.read_csv(stock_prices_file) # csv olvasása
df.set_index("Date", inplace=True) # dátumok használata

plt.figure(figsize=(12, 6)) # plot létrehozása

line_colors = { # szótár a vonalakra és színeikre
    "Open": "blue",
    "High": "green",
    "Low": "red",
    "Close": "purple"
}
for pos, color in line_colors.items(): # loopal kirajzolása szótárból
    df[pos].plot(color=color, label=pos)
plt.xlim(0,69)
plt.title("Tesla Stocks 2020-2021") # cím
plt.xlabel("Date") # dátum kiírása x labelre
plt.ylabel("Price ($)") # ár kiírása y labelre
plt.grid() # grid
plt.legend() # legend
plt.tight_layout() # layout formázása
plt.show() 