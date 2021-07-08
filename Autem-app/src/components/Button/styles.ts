import { StyleSheet } from 'react-native';
import { theme } from '../global/styles/theme';

export const styles = StyleSheet.create({
  container: {
    height: 50,
    width: 224,
    backgroundColor: 'transparent',
    borderRadius: 8,
    alignItems: 'center',
    justifyContent: 'center',
    marginTop: 30,
  },
  title: {
    flex: 1,
    color: theme.colors.heading,
    fontSize: 15,
    textDecorationLine: 'underline',
    textAlign: 'center',
    fontFamily: theme.fonts.title700,
  },
  bottonIcon: {
    backgroundColor: 'transparent'
  },
  iconWrapper: {
    width: 68,
    height: 68,
    justifyContent: 'center',
    alignItems: 'center',
    borderRightWidth: 1,
    backgroundColor: 'red'
  },
  icon: {
    width: 68,
    height: 68,
  },
  buttonAc: {
    width: 27,
    height: 27
  },
  buttonEnter: {
    width: 286,
    height: 104,
    backgroundColor: theme.colors.buttonEnter,
    borderRadius: 50,
    alignItems: 'center',
    justifyContent: 'center'
  },
  textEnter: {
    fontFamily: theme.fonts.title700,
    fontSize: 40,
    color: theme.colors.textColor
  },
  buttonGg: {
    width: 60,
    height: 60,
    marginRight: 5,
    marginTop: 10
  },
  buttonFc: {
    width: 60,
    height: 60,
    marginRight: 5,
    marginTop: 10
  },
  buttonIc: {
    width: 60,
    height: 60,
    marginTop: 10
  },
});