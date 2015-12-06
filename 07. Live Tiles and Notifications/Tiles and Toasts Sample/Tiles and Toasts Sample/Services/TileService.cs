using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiles_and_Toasts_Sample.Models;
using System.Xml.Linq;
using Windows.Data.Xml.Dom;
using NotificationsExtensions.Tiles;

namespace Tiles_and_Toasts_Sample.Services
{
    public class TileService
    {
        public static XmlDocument CreateTile(DailyForecast[] forecast)
        {
            //var tileContent = new TileContent()
            //{
            //    Visual = new TileVisual()
            //    {
            //        TileSmall = new TileBinding()
            //        {
            //            Content = new TileBindingContentAdaptive()
            //            {
            //                BackgroundImage = new TileBackgroundImage()
            //                {
            //                    Source = new TileImageSource("Assets/Weather/Mostly Cloudy-Background.jpg"),
            //                    Overlay = 30
            //                },
            //                TextStacking = TileTextStacking.Center,
            //                Children =
            //                {
            //                    new TileText()
            //                    {
            //                        Text = forecast[0].weekday,
            //                        Style = TileTextStyle.Body,
            //                        Align = TileTextAlign.Center
            //                    },new TileText()
            //                    {
            //                        Text = forecast[0].daytemp,
            //                        Style = TileTextStyle.Base,
            //                        Align = TileTextAlign.Center
            //                    }
            //                }                   
            //            }

            //        }
            //        /// All other tiles
            //    }
            //};

            var tileXML = new XmlDocument();
            var tileXMLText = String.Format(
                @"<?xml version='1.0' encoding='utf-8'?>
                    <tile><visual displayName='{0}' baseUri='Assets/Weather/'>", forecast[0].city);

            // Small Tile 
            tileXMLText += String.Format(
               @"<binding template='TileSmall' hint-textStacking='center' hint-overlay='30'>
                    <image src='Mostly Cloudy-Background.jpg' placement='background' />
                    <text hint-style='body' hint-align='center'>{0}</text>
                    <text hint-style='base' hint-align='center'>{1}</text>
                </binding>", forecast[0].weekday, forecast[0].daytemp);

            // Medium Tile
            tileXMLText += String.Format(
                @"<binding template='TileMedium' branding='name' hint-overlay='30' >
                  <image src='Mostly Cloudy-Background.jpg' placement='background' />
                  <group >
                    <subgroup >
                      <text hint-align='center'>{0}</text >
                      <image src='{1}.png' hint-removeMargin='true' />
                      <text hint-align='center'>{2}</text >
                      <text hint-style='captionsubtle' hint-align='center'>{3}</text >
                    </subgroup >
                    <subgroup >
                      <text hint-align='center'>{4}</text >
                      <image src='{5}.png' hint-removeMargin='true' />
                      <text hint-align='center' >{6}</text >
                      <text hint-style='captionsubtle' hint-align='center'>{7}</text >
                    </subgroup >
                  </group >
                </binding >", forecast[0].weekday, forecast[0].weather, forecast[0].daytemp, forecast[0].nighttemp,
                forecast[1].weekday, forecast[1].weather, forecast[1].daytemp, forecast[1].nighttemp);

            // Wide Tile
            tileXMLText +=
                @"<binding template='TileWide' branding='nameAndLogo' hint-overlay='30' >
                  <image src='Mostly Cloudy-Background.jpg' placement='background' />
                  <group>";

            for (var i = 0; i < 5; i++)
            {
                tileXMLText += String.Format(
                   @"<subgroup hint-weight='1'>
                        <text hint-align='center'>{0}</text>
                        <image src='{1}.png' hint-removeMargin='true' />
                        <text hint-align='center'>{2}</text >
                        <text hint-style='captionsubtle' hint-align='center' >{3}</text >
                    </subgroup >",
                   forecast[i].weekday, forecast[i].weather, forecast[i].daytemp, forecast[i].nighttemp
                );
            }

            tileXMLText += @"</group></binding>";

            // end
            tileXMLText += " </visual ></tile >";

            tileXML.LoadXml(tileXMLText);

            return tileXML;
        }
    }
}
