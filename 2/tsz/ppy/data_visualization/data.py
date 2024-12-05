import pandas as pd
import plotly.express as px

df = pd.read_excel("datadump.xlsx")
fig = px.scatter(df,
                 x="ID",
                 y="Életkora?",
                 color="Neme?",
                 size="Magassága? (cm)")
#fig.show()
df = df.drop()
fig2 = px.bar(df,
              x="Testsúlya? (kg)",
              y="Magassága? (cm)")
fig2.show()