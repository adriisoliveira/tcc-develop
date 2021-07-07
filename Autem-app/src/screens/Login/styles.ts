import { theme } from "../../components/global/styles/theme";
import { StyleSheet } from "react-native";

export const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  image: {
    width: 153,
    height: 153,
    justifyContent: 'center',
    alignItems: 'center',
    paddingTop: 100
  },
  containerLogo: {
    width: 224,
    height: 224,
    backgroundColor: theme.colors.heading,
    borderColor: theme.colors.heading,
    borderRadius: 24,
    marginTop: 260,
    marginLeft: 95,
    marginRight: 95,
    justifyContent: 'center',
    alignItems: 'center'
  }
});