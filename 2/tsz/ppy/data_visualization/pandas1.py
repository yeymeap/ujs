import numpy as np
import matplotlib.pyplot as plt
import pandas as pd

x = {
    "Éjszaka":[10, 13, 15, 11, 12, 9, 5, 6, 8, 11],
    "Nappal":[13, 15, 16, 13, 10, 7, 6, 7, 9, 13]
}

y = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

df = pd.DataFrame(x,y)
#print(df)
#df.head()
#print(type(df))

df.plot(kind="line",
        grid=True,
        title="Hőmérséklet előrejelzés",
        legend=False,
        xlim=(1,10),
        color = ("blue", "red"),
        ls = "-.")
plt.show()

df_2 = pd.read_csv("msft.csv")[::-1].reset_index(drop=True)
#df_2.head()
#print(df_2)

df_2.plot(kind="line",
          grid=True,
          legend=True,
          title="MSFT",
          xlim=(0,20))
plt.show()