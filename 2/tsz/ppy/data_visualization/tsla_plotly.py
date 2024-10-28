import plotly.graph_objects as go
import pandas as pd

stock_prices_file = "tsla_plt.csv" # csv fájl neve
df = pd.read_csv(stock_prices_file) # csv olvasása

fig = go.Figure(data=[go.Candlestick(x=df['Date'], # plotly használata
                open=df['Open'],
                high=df['High'],
                low=df['Low'],
                close=df['Close'])])

fig.update_layout(
    xaxis_rangeslider_visible=False, # slider kikapcsolása
    title = "Tesla stocks 2019-2024", # cím
    title_x = 0.5, # cím középre
    yaxis_title = "Prices in $", # y tengely cím
    shapes = [dict(
        x0='2020-04-01', x1='2021-11-01', y0=0, y1=1, xref='x', yref='paper', 
        line_width=2), # téglalap 
            dict(x0='2021-11-01', x1='2023-01-01', y0=0, y1=1, xref='x', yref='paper',
        line_width=2)], # téglalap
    annotations=[dict(
        x='2020-11-01', y=0.1, xref='x', yref='paper',
        showarrow=False, xanchor='left', text='Increase period'), # szöveg a téglalap mellé
                 dict(
        x='2022-03-01', y=0.1, xref='x', yref='paper',
        showarrow=False, xanchor='left', text='Decrease period')] # szöveg téglalap mellé
 ) 

fig.show()