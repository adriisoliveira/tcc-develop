import { StyleSheet } from 'react-native';
import { theme } from '../global/styles/theme';

export const styles = StyleSheet.create({
  container: {
    height: 50,
    width: 224,
    backgroundColor: theme.colors.heading,
    borderRadius: 8,
    alignItems: 'center',
    justifyContent: 'center',
    marginTop: 30
  },
  title: {
    flex: 1,
    color: theme.colors.primary,
    fontSize: 20,
    textAlign: 'center',
    fontFamily: theme.fonts.title700,
  },
});