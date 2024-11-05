import pandas as pd
import plotly.express as px

df = pd.read_csv("cars.csv", delimiter = ",")
#print(df.head(5))
#print(len(df))

df["Length"] = df["Length"] * 2.54
df["Width"] = df["Width"] * 2.54
df["Height"] = df["Height"] * 2.54

#print(sum(df.Make == "Audi")) # de ez is lehetséges
print(sum(df["Make"] == "Audi")) # preferált formátum
#print(sum(df["Make"] == "BMW"))

print(df["Make"].value_counts())
print(df["Year"].value_counts())

fig = px.scatter(df,
                 x="Highway mpg",
                 y="City mpg",
                 color="Driveline",
                 symbol="Classification",
                 size="Height")
fig.show()