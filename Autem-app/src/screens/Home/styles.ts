import { theme } from "../../components/global/styles/theme";
import { getBottomSpace, getStatusBarHeight } from 'react-native-iphone-x-helper';
import { StyleSheet } from "react-native";

export const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  reports: {
    marginTop: 32,
    flexDirection: 'column',
    justifyContent: 'center',
    marginHorizontal: 68,
    paddingTop: 128
  },
  bloco1: {
    height: 160,
    width: 280,
    borderRadius: 30,
    marginBottom: 15,
    backgroundColor: 'black'
  },
  bloco2: {
    height: 160,
    width: 280,
    borderRadius: 30,
    marginBottom: 15,
    backgroundColor: 'blue'
  },
  bloco3: {
    height: 160,
    width: 280,
    borderRadius: 30,
    marginBottom: 15,
    backgroundColor: 'yellow'
  },
  bloco4: {
    height: 160,
    width: 280,
    borderRadius: 30,
    marginBottom: 15,
    backgroundColor: 'red'
  },
  containerNavigation: {
    flex: 1,
    alignItems: "center",
    justifyContent: "center",
    padding: 16
  },
  navigationContainer: {
    backgroundColor: "#ecf0f1"
  },

});