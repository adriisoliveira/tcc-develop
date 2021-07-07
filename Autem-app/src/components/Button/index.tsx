import React from 'react';
import { Text } from 'react-native';
import { RectButton, RectButtonProps } from 'react-native-gesture-handler';
import { MaterialCommunityIcons } from '@expo/vector-icons';

import { styles } from './styles';
import { theme } from '../global/styles/theme';

type Props = RectButtonProps & {
  title: string;
}

export function Button({ title, ...rest } : Props) {
  return (
    <RectButton
      style={styles.container}
      {...rest}
    >
      <MaterialCommunityIcons
        color={theme.colors.heading}
        size={24}
      />
      <Text style={styles.title}>
        { title }
      </Text>
    </RectButton>
  )
}