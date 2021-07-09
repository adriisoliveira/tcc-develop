import { theme } from "../../components/global/styles/theme";
import { getBottomSpace, getStatusBarHeight } from 'react-native-iphone-x-helper';
import { StyleSheet } from "react-native";

export const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  createAccount: {
    alignItems: 'flex-end',
    marginTop: getStatusBarHeight() + 37,
    marginRight: 28,
    marginLeft: 208,
    flexDirection: 'row',
    justifyContent: 'flex-end'
  },
  text: {
    fontFamily: theme.fonts.title700,
    fontSize: 29,
    color: theme.colors.textColor
  },
  inputs: {
    width: 353,
    height: 70,
    marginTop: 221,
    marginLeft: 36,
    flexDirection: 'column',
    justifyContent: 'center',
  },
  textInput: {
    height: 40,
    color: theme.colors.heading,
    borderColor: theme.colors.heading,
    borderWidth: 1,
    fontFamily: theme.fonts.title700,
    fontSize: 20,
    marginTop: 6
  },
  buttonsLogin: {
    flexDirection: 'column'
  },
  password: {
    alignItems: 'center'
  },
  buttonEnter: {
    marginTop: 110,
    alignItems: 'center'
  },
  buttonSocialMidia: {
    flexDirection: 'row',
    alignItems: 'center',
    marginTop: 10,
    justifyContent: 'center',
  }
});